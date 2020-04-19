class Hamming
  def self.compute(strand_a, strand_b)
    if strand_a.length != strand_b.length
      raise ArgumentError, 'Strands have different lengths'
    end

    strand_a
      .chars
      .zip(strand_b.chars)
      .count { |x, y| x != y }
  end
end
