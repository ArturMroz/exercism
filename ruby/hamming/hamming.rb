class Hamming
  def self.compute(strand_a, strand_b)
    if strand_a.length != strand_b.length
      raise ArgumentError, 'Strands have different lengths'
    end
    
    strand_a
      .split("")
      .zip(strand_b.split(""))
      .sum { |x, y| x != y ? 1 : 0 }
  end
end
