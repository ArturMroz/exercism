class Proverb
  def initialize(*words, qualifier: nil)
    @words = words
    @qualifier = qualifier
  end

  def to_s
    @words
      .each_cons(2)
      .map { |a, b| "For want of a #{a} the #{b} was lost." }
      .push("And all for the want of a #{@qualifier} #{@words[0]}.".squeeze(' '))
      .join("\n")
  end
end
