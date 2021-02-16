class BinarySearch
  def initialize(array)
    @array = array
  end

  def search_for(needle)
    low = 0
    high = @array.size - 1

    while low <= high
      mid = (high + low) / 2

      return mid if @array[mid] == needle

      if @array[mid] < needle
        low = mid + 1
      else
        high = mid - 1
      end
    end

    nil
  end
end
