export class Matrix {
  constructor(str) {
    this.rows = str.split('\n').map(col => col.split(' ').map(Number));
    this.columns = this.rows.map((_, i) => this.rows.map(r => r[i]));
  }
}
