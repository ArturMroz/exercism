export default class Queens {
  constructor(coords) {
    this.BOARD_SIZE = 8;

    if (!coords) {
      this.white = [0, 3];
      this.black = [7, 3];
    } else {
      this.white = coords.white;
      this.black = coords.black;

      if (this.doQueensShareSpace()) {
        throw new Error('Queens cannot share the same space');
      }
    }
  }

  doQueensShareSpace() {
    return this.white[0] === this.black[0] && this.white[1] === this.black[1];
  }

  canAttack() {
    // check if queens are in the same row or column
    if (this.white[0] === this.black[0] || this.white[1] === this.black[1]) return true;

    // check all four diagonals
    const d = [[1, 1], [1, -1], [-1, 1], [-1, -1]].map(e => this.checkDiagonal(e));
    return d.some(v => v);

    // return this.checkDiagonal([1, 1]) || this.checkDiagonal([1, -1]) ||
    //   this.checkDiagonal([-1, 1]) || this.checkDiagonal([-1, -1]);
  }

  checkDiagonal([walkX, walkY]) {
    let [currentX, currentY] = [this.white[0], this.white[1]];
    const [bX, bY] = [this.black[0], this.black[1]];

    while (currentX >= 0 && currentX <= this.BOARD_SIZE && currentY >= 0 && currentY <= this.BOARD_SIZE) {
      currentX += walkX;
      currentY += walkY;

      if (currentX === bX && currentY === bY) return true;
    }

    return false;
  }

  toString() {
    const rowTemplate = Array(this.BOARD_SIZE).fill('_');

    let board = Array.from({ length: this.BOARD_SIZE }, () => [...rowTemplate]);

    const [wX, wY] = [this.white[0], this.white[1]];
    const [bX, bY] = [this.black[0], this.black[1]];
    board[wX][wY] = 'W';
    board[bX][bY] = 'B';

    // board.forEach(row => row = row.join(' '));
    board = board.map(row => row.join(' '));
    board[board.length - 1] += '\n';

    return board.join('\n');
  }
}
