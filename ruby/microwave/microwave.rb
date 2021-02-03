class Microwave
  attr_reader :timer

  def initialize(input)
    seconds = input.modulo(100) + input.div(100) * 60

    @timer = format('%02d:%02d', *seconds.divmod(60))
  end
end
