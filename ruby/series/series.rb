class Series
  def initialize(input)
    @input = input
  end

  def slices(size)
    raise ArgumentError if @input.length < size

    @input
      .chars
      .each_cons(size)
      .map(&:join)
  end
end
