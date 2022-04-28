package bowling

import "errors"

const (
	pinsPerFrame  = 10
	framesPerGame = 10
	rollsPerFrame = 2
)

type Game struct {
	frames   [framesPerGame][rollsPerFrame]int
	curFrame int
	curRoll  int
	fillBall int
}

func NewGame() *Game {
	return &Game{}
}

func (g *Game) Roll(pins int) error {
	if g.curFrame >= framesPerGame {
		return errors.New("game is over")
	}
	if pins < 0 || pins > pinsPerFrame {
		return errors.New("score for the roll out of bounds")
	}

	frame := &g.frames[g.curFrame]
	if g.curFrame < framesPerGame-1 { // not a final frame, normal rules apply
		frame[g.curRoll] = pins
		if (g.curRoll == 0 && pins == pinsPerFrame) || g.curRoll == 1 { // a strike or 2nd roll, move to the next frame
			if frame[0]+frame[1] > pinsPerFrame {
				return errors.New("invalid roll: more points in a frame than max pins")
			}
			g.curFrame++
			g.curRoll = 0
		} else {
			g.curRoll = 1
		}
	} else { // special rules for the final frame
		if g.curRoll == 2 { // final bonus roll
			if frame[1] != pinsPerFrame && // 2nd roll isn't a strike
				frame[0]+frame[1] != pinsPerFrame && // final frame isn't a spare
				frame[1]+pins > pinsPerFrame {
				return errors.New("invalid bonus roll")
			}
			g.fillBall = pins
			g.curFrame++ // game over
			return nil
		}
		frame[g.curRoll] = pins
		if g.curRoll == 1 && frame[0]+frame[1] < pinsPerFrame {
			g.curFrame++ // game over; no strike or spare means no bonus roll :(
			return nil
		}
		g.curRoll++
	}

	return nil
}

func (g *Game) Score() (score int, err error) {
	if g.curFrame < framesPerGame {
		return 0, errors.New("game has to be finished before scoring")
	}

	for i := 0; i < framesPerGame-1; i++ {
		firstRoll, secondRoll := g.frames[i][0], g.frames[i][1]
		score += firstRoll + secondRoll
		// it's a spare or strike, add next throw to current frame score
		if firstRoll+secondRoll == pinsPerFrame {
			score += g.frames[i+1][0]
		}
		// it's a strike, add 1 more throw to current frame score
		if firstRoll == pinsPerFrame {
			// reach even one frame further if next throw is also a strike and we aren't reaching over final frame
			if g.frames[i+1][0] == pinsPerFrame && i+2 != framesPerGame {
				score += g.frames[i+2][0]
			} else {
				score += g.frames[i+1][1]
			}
		}
	}

	// final frame, bonuses need not apply
	score += g.frames[framesPerGame-1][0] + g.frames[framesPerGame-1][1] + g.fillBall

	return score, nil
}
