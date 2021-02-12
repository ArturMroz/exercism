class RunLengthEncoding
  def self.encode(input)
    input.gsub(/(.)\1+/) { |s| "#{s.size}#{s.chr}" }
  end

  def self.decode(input)
    input.gsub(/(\d+)(\D)/) { $2 * $1.to_i }
  end
end
