class SumOfMultiples
  def initialize(*divisors)
    @divisors = divisors
  end

  def to(limit)
    (1...limit)
      .select { |n| @divisors.any? { |m| (n % m).zero? } }
      .sum
  end
end
