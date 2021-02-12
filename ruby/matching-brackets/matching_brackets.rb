class Brackets
  PAIRS = { '{' => '}', '(' => ')', '[' => ']' }.freeze

  def self.paired?(input)
    input.chars.each_with_object([]) do |ch, stack|
      if PAIRS.keys.include?(ch)
        stack.push(PAIRS[ch])
      elsif PAIRS.values.include?(ch)
        return false unless ch == stack.pop
      end
    end.empty?
  end
end
