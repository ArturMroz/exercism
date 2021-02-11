class Palindromes
  attr_reader :smallest, :largest

  Result = Struct.new(:value, :factors)

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

        if product < smallest_product
          @smallest = Result.new(product, [[a, b]])
          smallest_product = product
        elsif product == smallest_product
          @smallest&.factors&.push([a, b])
        end

        if product > largest_product
          @largest = Result.new(product, [[a, b]])
          largest_product = product
        elsif product == largest_product
          @largest&.factors&.push([a, b])
        end
      end
    end
  end
end
