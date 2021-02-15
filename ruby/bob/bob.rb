class Bob
  def self.hey(remark)
    remark.strip!

    if shouting?(remark) && question?(remark)
      "Calm down, I know what I'm doing!"
    elsif shouting?(remark)
      'Whoa, chill out!'
    elsif question?(remark)
      'Sure.'
    elsif silence?(remark)
      'Fine. Be that way!'
    else
      'Whatever.'
    end
  end

  def self.shouting?(s)
    s == s.upcase && s.count('a-zA-Z') > 0
  end

  def self.question?(s)
    s.end_with? '?'
  end

  def self.silence?(s)
    s.empty?
  end

  private_class_method :shouting?, :question?, :silence?
end
