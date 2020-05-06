class Matrix
  attr_reader :rows
  attr_reader :columns

  def initialize(input)
    @rows =
      input
        .lines
        .map { |row| row.split.map(&:to_i) }

    @columns = rows.transpose
  end
end
