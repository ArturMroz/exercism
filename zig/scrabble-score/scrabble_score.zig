pub fn score(s: []const u8) u32 {
    var result: u32 = 0;

    for (s) |ch| {
        result += switch (toUpper(ch)) {
            'D', 'G' => 2,
            'B', 'C', 'M', 'P' => 3,
            'F', 'H', 'V', 'W', 'Y' => 4,
            'K' => 5,
            'J', 'X' => 8,
            'Q', 'Z' => 10,
            else => 1,
        };
    }

    return result;
}

fn toUpper(ch: u8) u8 {
    return switch (ch) {
        'a'...'z' => ch - 32,
        else => ch,
    };
}
