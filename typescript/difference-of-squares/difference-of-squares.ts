export default class {
  squareOfSum: number
  sumOfSquares: number
  difference: number

  constructor(n: number) {
    this.squareOfSum = (n * (n + 1) / 2) ** 2
    this.sumOfSquares = n * (n + 1) * (2 * n + 1) / 6
    this.difference = this.squareOfSum - this.sumOfSquares
  }
}
