class PhoneNumber
  def self.clean(number)
    cleaned = number.gsub(/\D/, '').gsub(/^1/, '')

    cleaned if cleaned.match?(/^([2-9]\d{2})?[2-9]\d{6}$/)
  end
end
