class Phrase
  def initialize(phrase)
    @phrase = phrase
  end

  def word_count
    @phrase
      .downcase
      .scan(/\d+|\w+'?\w+/)
      .each_with_object(Hash.new(0)) { |word, counts| counts[word] += 1 }
  end
end
