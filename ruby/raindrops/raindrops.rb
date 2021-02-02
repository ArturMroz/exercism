class Raindrops
  SOUNDS = {
    3 => 'Pling',
    5 => 'Plang',
    7 => 'Plong'
  }.freeze

  def self.convert(n)
    result =
      SOUNDS
        .map { |key, val| val if (n % key).zero? }
        .join

    result.empty? ? n.to_s : result
  end
end
