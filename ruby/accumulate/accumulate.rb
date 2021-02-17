class Array
  def accumulate(&block)
    each_with_object([]) do |elt, result|
      result << block.call(elt)
    end
  end
end
