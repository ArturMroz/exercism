use criterion::{black_box, criterion_group, criterion_main, Criterion};

fn test_multiple_anagrams(b: &mut Criterion) {
    let word = "allergy";

    let inputs = [
        "gallery",
        "ballerina",
        "regally",
        "clergy",
        "largely",
        "leading",
    ];

    // let outputs = vec!["gallery", "regally", "largely"];

    b.bench_function("anagram_multiple", |b| b.iter(|| anagram::anagrams_for(&word, &inputs)));
}

criterion_group!(benches, test_multiple_anagrams);
criterion_main!(benches);