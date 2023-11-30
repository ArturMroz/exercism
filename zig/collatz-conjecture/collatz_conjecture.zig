pub const ComputationError = error{IllegalArgument};

pub fn steps(number: usize) ComputationError!usize {
    if (number <= 0) return error.IllegalArgument;

    var n: usize = number;
    var i: usize = 0;

    while (n != 1) : (i += 1) {
        n = if (n % 2 == 0) n / 2 else n * 3 + 1;
    }

    return i;
}
