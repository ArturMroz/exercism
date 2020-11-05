pub fn is_armstrong_number(num: u32) -> bool {
    let digits = get_digits(num);
    let len = digits.len() as u32;

    let armstrong_number: u32 = digits
        .into_iter()
        .map(|x| x.pow(len))
        .sum();

    armstrong_number == num
}

fn get_digits(num: u32) -> Vec<u32> {
    let mut digits: Vec<u32> = vec![];
    let mut _temp = num;

    while _temp > 0 {
        digits.push(_temp % 10);
        _temp /= 10;
    }

    digits
}
