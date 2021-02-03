class Isogram
  def self.isogram?(input)
    trimmed = input.tr('- ', '')
    unique_chars = trimmed.downcase.chars.uniq
    unique_chars.length == trimmed.length
  end
end
