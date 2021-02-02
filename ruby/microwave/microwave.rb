class Microwave
  def initialize(seconds)
    @seconds =
      if seconds < 100
        seconds
      else
        seconds.modulo(100) + seconds.div(100) * 60
      end
  end

  def timer
    format('%02d:%02d', @seconds.div(60), @seconds.modulo(60))
  end
end
