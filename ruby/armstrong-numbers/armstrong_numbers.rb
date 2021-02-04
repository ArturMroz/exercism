class ArmstrongNumbers
  def self.include?(n)
    digits = n.digits
    n == digits.sum { |d| d**digits.length }
  end
end
