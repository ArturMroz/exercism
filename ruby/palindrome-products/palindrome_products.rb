class Palindromes
  attr_reader :largest, :smallest

  def initialize(max_factor:, min_factor: 1)
    @min = min_factor
    @max = max_factor
  end

  def generate
    smallest_product = @max**2
    largest_product = 1

    (@min..@max).each do |a|
      (a..@max).each do |b|
        product = a * b

        next if product.to_s != product.to_s.reverse

        if product == smallest_product
          @smallest&.add_factors(a, b)
        elsif product < smallest_product
          @smallest = Result.new(product, a, b)
          smallest_product = product
        end

        if product == largest_product
          @largest&.add_factors(a, b)
        elsif product > largest_product
          @largest = Result.new(product, a, b)
          largest_product = product
        end
      end
    end
  end
end

class Result
  attr_reader :value, :factors

  def initialize(product, *factors)
    @value = product
    @factors = [factors]
  end

  def add_factors(*factors)
    @factors.push(factors)
  end
end
