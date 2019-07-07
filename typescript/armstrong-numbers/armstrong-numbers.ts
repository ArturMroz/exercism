export default class {
  static isArmstrongNumber(n: number): boolean {
    const digits = this.getDigits(n)
    const armstrong = digits
      .reduce((acc, curr) => acc + Math.pow(curr, digits.length), 0)

    return armstrong === n
  }

  static getDigits(n: number): number[] {
    const retVal = []

    while (n > 0) {
      const temp = n % 10
      retVal.push(temp)
      n = Math.floor(n / 10)
    }

    return retVal
  }
}