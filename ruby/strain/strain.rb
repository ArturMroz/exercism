class Array
  def keep(&block)
    each_with_object([]) do |elt, result|
      result << elt if block.call(elt)
    end
  end

  def discard(&block)
    each_with_object([]) do |elt, result|
      result << elt unless block.call(elt)
    end
  end
end
