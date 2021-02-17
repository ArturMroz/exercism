class Matrix
  attr_reader :rows, :columns

  def initialize(raw_matrix)
    @rows =
      raw_matrix
        .lines
        .map { |l| l.split.map(&:to_i) }

    @columns = @rows.transpose
  end

  def saddle_points
    results = []

    @rows.each_index do |x|
      @columns.each_index do |y|
        results << [x, y] if @rows[x].max == @columns[y].min
      end
    end

    results
  end
end
