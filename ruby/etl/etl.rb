class ETL
  def self.transform(old_values)
    old_values.each_with_object({}) do |(key, value), new_values|
      value.each { |el| new_values[el.downcase] = key }
    end
  end
end
