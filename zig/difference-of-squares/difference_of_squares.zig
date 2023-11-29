pub fn squareOfSum(number: usize) usize {
    var result: usize = 0;
    for (1..number + 1) |i| {
        result += i;
    }
    return result * result;
}

pub fn sumOfSquares(number: usize) usize {
    var result: usize = 0;
    for (1..number + 1) |i| {
        result += i * i;
    }
    return result;
}

pub fn differenceOfSquares(number: usize) usize {
    return squareOfSum(number) - sumOfSquares(number);
}
