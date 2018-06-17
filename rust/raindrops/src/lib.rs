pub fn raindrops(n: usize) -> String {
    let mut output = String::new();
    if n % 3 == 0 { output += "Pling" };
    if n % 5 == 0 { output += "Plang" };
    if n % 7 == 0 { output += "Plong" };
    
    if output.is_empty() { n.to_string() } else { output }
}
