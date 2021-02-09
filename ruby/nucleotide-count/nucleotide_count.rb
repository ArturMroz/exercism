class Nucleotide
  def initialize(strand)
    raise ArgumentError if strand.match(/[^ATCG]/)

    @strand = strand
  end

  def self.from_dna(strand)
    new(strand)
  end

  def count(nucleotide)
    @strand.count(nucleotide)
  end

  def histogram
    empty_histogram = { 'A' => 0, 'T' => 0, 'C' => 0, 'G' => 0 }

    @strand
      .chars
      .each_with_object(empty_histogram) { |char, dict| dict[char] += 1 }
  end
end
