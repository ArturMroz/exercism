class Sieve
  attr_reader :primes

  def initialize(limit)
    @primes = [nil, nil, *2..limit]

    (2..limit).each do |i|
      next unless @primes[i]

      (i + i..limit).step(i).each do |j|
        @primes[j] = nil
      end
    end

    @primes.compact!
  end
end
