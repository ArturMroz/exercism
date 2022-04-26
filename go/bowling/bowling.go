package bowling

import "errors"

type Game struct {
	frames   [10][2]int
	curFrame int
	curRoll  int
	fillBall int
}

func NewGame() *Game {
	return &Game{}
}

func (g *Game) Roll(pins int) error {
	if g.curFrame > 9 {
		return errors.New("game is over")
	}
	if pins < 0 || pins > 10 {
		return errors.New("score for the roll out of bounds")
	}

	// special rules for the final frame
	if g.curFrame == 9 {
		finalFrame := &g.frames[g.curFrame]
		if g.curRoll == 0 {
			finalFrame[g.curRoll] = pins
			g.curRoll++
		} else if g.curRoll == 1 {
			finalFrame[g.curRoll] = pins
			if finalFrame[0]+finalFrame[1] < 10 {
				g.curFrame++ // game over
			} else {
				g.curRoll++
			}
		} else if g.curRoll == 2 {
			if finalFrame[1] != 10 &&
				finalFrame[0]+finalFrame[1] != 10 &&
				finalFrame[1]+pins > 10 {
				return errors.New("invalid fill ball roll")
			}
			g.fillBall = pins
			g.curFrame++ // game over
		}
		return nil
	}

	frame := &g.frames[g.curFrame]
	g.frames[g.curFrame][g.curRoll] = pins
	if g.curRoll == 0 && pins == 10 {
		g.curFrame++ // that's a strike, move to the next frame straightaway
	} else if g.curRoll == 0 {
		g.curRoll = 1
	} else if g.curRoll == 1 {
		if frame[0]+frame[1] > 10 {
			return errors.New("invalid roll: more than 10 points in a frame")
		}
		g.curFrame++
		g.curRoll = 0
	}

	return nil
}

func (g *Game) Score() (score int, err error) {
	if g.curFrame != 10 {
		return 0, errors.New("game has to be finished before scoring")
	}

	for i := 0; i < 9; i++ {
		curFrame := g.frames[i]
		score += curFrame[0] + curFrame[1]
		// it's a spare or strike, add next throw to current frame score
		if curFrame[0]+curFrame[1] == 10 {
			score += g.frames[i+1][0]
		}
		// it's a strike, add 1 more throw to current frame score
		if curFrame[0] == 10 {
			// next throw is also a strike and we aren't at a final frame, reach one frame further
			if g.frames[i+1][0] == 10 && i+2 != 10 {
				score += g.frames[i+2][0]
			} else {
				score += g.frames[i+1][1]
			}
		}
	}

	// final frame
	score += g.frames[9][0] + g.frames[9][1] + g.fillBall

	return score, nil
}
