class Anagram
  def initialize(word)
    @word = word.downcase
  end

  def match(candidates)
    candidates.select do |candidate|
      candidate.downcase != @word &&
        candidate.downcase.chars.sort == @word.chars.sort
    end
  end
end
