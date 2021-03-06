class Triangle
  def initialize(sides)
    @sides = sides
  end

  def equilateral?
    valid? && @sides.uniq.size == 1
  end

  def isosceles?
    valid? && @sides.uniq.size <= 2
  end

  def scalene?
    valid? && @sides.uniq.size == 3
  end

  def valid?
    @sides.all? { |side| side < @sides.sum - side }
  end
end
