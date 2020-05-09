class Phrase
  attr_reader :word_count

  def initialize(phrase)
    @word_count =
      phrase
        .downcase
        .scan(/\d+|\w+'?\w+/)
        .each_with_object(Hash.new(0)) { |word, counts| counts[word] += 1 }
  end
end
