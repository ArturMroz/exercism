use std::collections::HashSet;

pub fn anagrams_for<'a>(word: &'a str, possible_anagrams: &'a [&str]) -> HashSet<&'a str> {
    let sorted_word = sort_str(&word);
    let lowercased_word = word.to_lowercase();

    possible_anagrams
        .iter()
        .cloned()
        .filter(|x| lowercased_word != x.to_lowercase() && sorted_word == sort_str(x))
        .collect()
}

fn sort_str(s: &str) -> Vec<char> {
    let mut ret_val: Vec<char> = s.to_lowercase().chars().collect();
    ret_val.sort();

    ret_val
}