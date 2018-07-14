class Hamming
  def self.compute(strand_a, strand_b)
    if strand_a.length != strand_b.length
      raise ArgumentError, 'Strands have different length'
    end
    
    sum = 0
    strand_a.split("").zip(strand_b.split("")).each{|x, y| sum += x != y ? 1 : 0}
    sum
  end
end

module BookKeeping
  VERSION = 3 
end