const math = @import("std").math;

pub fn isArmstrongNumber(num: u128) bool {
    var n = num;
    var numDigits: u8 = 0;

    while (n > 0) : (n /= 10) {
        numDigits += 1;
    }

    n = num;
    var sum: u128 = 0;

    while (n > 0) : (n /= 10) {
        sum += math.pow(u128, n % 10, numDigits);
    }

    return num == sum;
}
