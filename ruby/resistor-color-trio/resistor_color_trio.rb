class ResistorColorTrio
  COLORS = %w[
    black
    brown
    red
    orange
    yellow
    green
    blue
    violet
    grey
    white
  ].freeze

  def initialize(colors)
    raise ArgumentError if (colors - COLORS).any?

    @colors = colors
  end

  def label
    tens, units, magnitude = @colors.map { |c| COLORS.index c }
    value = (tens * 10 + units) * 10**magnitude

    "Resistor value: #{value} ohms".gsub(/0{3} /, ' kilo')
  end
end
