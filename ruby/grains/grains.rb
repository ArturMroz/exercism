class Grains
  MAX_SQUARE = 64

  def self.square(n)
    raise ArgumentError if n < 1 || n > MAX_SQUARE

    1 << (n - 1)
  end

  def self.total
    (1 << MAX_SQUARE) - 1
  end
end
