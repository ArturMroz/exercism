class PerfectNumber
  def self.classify(n)
    raise RuntimeError if n <= 0

    aliquot = (1..n / 2).select { |x| (n % x).zero? }.sum

    if aliquot > n
      'abundant'
    elsif aliquot < n
      'deficient'
    else
      'perfect'
    end
  end
end
