class Acronym
  def self.abbreviate(sentence)
    sentence
      .split(/\W+/)
      .map(&:chr)
      .join
      .upcase
  end
end
