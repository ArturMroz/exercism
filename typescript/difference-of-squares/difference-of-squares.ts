export default class {
  squareOfSum: number
  sumOfSquares: number
  difference: number

  constructor(n: number) {
    const sum = n * (n + 1) / 2
    this.squareOfSum = sum * sum
    this.sumOfSquares = n * (n + 1) * (2 * n + 1) / 6
    this.difference = this.squareOfSum - this.sumOfSquares
  }
}