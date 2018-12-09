export default class Queens {
  constructor({ white, black } = { white: [0, 3], black: [7, 3] }) {
    this.BOARD_SIZE = 8;

    this.white = white;
    this.black = black;

    if (this.white[0] === this.black[0] && this.white[1] === this.black[1]) {
      throw new Error('Queens cannot share the same space');
    }
  }

  canAttack() {
    const dX = this.white[0] - this.black[0];
    const dY = this.white[1] - this.black[1];
    return !dX || !dY || dX * dX === dY * dY;
  }

  toString() {
    const board = [...Array(this.BOARD_SIZE)].map(() => Array(this.BOARD_SIZE).fill('_'));

    board[this.white[0]][this.white[1]] = 'W';
    board[this.black[0]][this.black[1]] = 'B';

    return `${board.map(row => row.join(' ')).join('\n')}\n`;
  }
}
