export default class {
    static isArmstrongNumber(n: number): boolean {
        const digits = n.toString().split('')
        const armstrongSum = digits
            .reduce((acc, curr) => acc + Number(curr) ** digits.length, 0)

        return armstrongSum === n
    }

    static isArmstrongNumber2(n: number): boolean {
        const digits = this.getDigits(n)
        const armstrongSum = digits
            .reduce((acc, curr) => acc + curr ** digits.length, 0)

        return armstrongSum === n
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
