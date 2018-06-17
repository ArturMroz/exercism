pub fn twofer(name: &str) -> String {
    let name = if name.is_empty() { "you" } else { name };
    String::from(format!("One for {}, one for me.", name))
}
