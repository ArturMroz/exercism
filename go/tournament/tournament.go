package tournament

import (
	"bufio"
	"errors"
	"fmt"
	"io"
	"sort"
	"strings"
)

type scoreLine struct {
	team                string
	wins, draws, losses int
	played, points      int
}

type scoreBoard []scoreLine

// Tally pretty prints results of a small tournament.
func Tally(r io.Reader, w io.Writer) error {
	scoreBoard := make(scoreBoard, 0, 4)
	sc := bufio.NewScanner(r)
	for sc.Scan() {
		line := sc.Text()
		parts := strings.Split(line, ";")

		if len(parts) == 1 {
			continue
		}
		if len(parts) != 3 {
			return errors.New("invalid input data")
		}

		team1 := parts[0]
		team2 := parts[1]
		result := parts[2]

		switch result {
		case "win":
			scoreBoard.addWin(team1)
			scoreBoard.addLoss(team2)
		case "loss":
			scoreBoard.addLoss(team1)
			scoreBoard.addWin(team2)
		case "draw":
			scoreBoard.addDraw(team1)
			scoreBoard.addDraw(team2)
		default:
			return errors.New("invalid input data")
		}
	}
	if err := sc.Err(); err != nil {
		return err
	}

	sort.Slice(scoreBoard, func(i, j int) bool {
		if scoreBoard[i].points > scoreBoard[j].points {
			return true
		}
		if scoreBoard[i].points < scoreBoard[j].points {
			return false
		}
		return scoreBoard[i].team < scoreBoard[j].team
	})

	w.Write([]byte("Team                           | MP |  W |  D |  L |  P\n"))
	for _, v := range scoreBoard {
		_, err := fmt.Fprintf(
			w,
			"%-30s | %2d | %2d | %2d | %2d | %2d\n",
			v.team, v.played, v.wins, v.draws, v.losses, v.points)
		if err != nil {
			return err
		}
	}
	return nil
}

func (s *scoreBoard) addWin(teamName string) {
	for i := range *s {
		if (*s)[i].team == teamName {
			(*s)[i].played++
			(*s)[i].wins++
			(*s)[i].points += 3
			return
		}
	}
	*s = append(*s, scoreLine{team: teamName, played: 1, wins: 1, points: 3})
}

func (s *scoreBoard) addLoss(teamName string) {
	for i := range *s {
		if (*s)[i].team == teamName {
			(*s)[i].played++
			(*s)[i].losses++
			return
		}
	}
	*s = append(*s, scoreLine{team: teamName, played: 1, losses: 1})
}

func (s *scoreBoard) addDraw(teamName string) {
	for i := range *s {
		if (*s)[i].team == teamName {
			(*s)[i].played++
			(*s)[i].draws++
			(*s)[i].points++
			return
		}
	}
	*s = append(*s, scoreLine{team: teamName, played: 1, draws: 1, points: 1})
}
