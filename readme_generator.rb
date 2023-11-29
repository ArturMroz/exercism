text = %(
# Exercism.io solutions

> You should not have a favourite weapon. To become over-familiar with one weapon is as much a fault as not knowing it sufficiently well.
>
> ― Miyamoto Musashi, The Book of Five Rings

My solutions to [exercism.io](https://exercism.io) problems implemented in different programming languages.
)

langs_fmt = {
  'clojure'         => 'Clojure',
  'csharp'          => 'C#',
  'elm'             => 'Elm',
  'emacs-lisp'      => 'Elisp',
  'fsharp'          => 'F#',
  'go'              => 'Go',
  'haskell'         => 'Haskell',
  'javascript'      => 'JavaScript',
  'python'          => 'Python',
  'ruby'            => 'Ruby',
  'rust'            => 'Rust',
  'typescript'      => 'TypeScript',
  'x86-64-assembly' => 'Assembly',
  'zig'             => 'Zig',
}

solutions = Dir['*/*']
problems = Hash.new { [] }
langs_count = Hash.new(0)

solutions.each do |dir|
  lang, problem = dir.split('/')
  problems[problem] <<= lang
  langs_count[lang] += 1
end

text += %(
## Stats

Total: #{solutions.size} solutions, #{problems.size} unique problems, #{langs_fmt.size} languages.

| Language | No of solutions | % of total solutions |
| --- | --- | --- |
)

langs_count.sort_by { |_, v| -v }.each do |lang, count|
  total_percent = (count.to_f / solutions.size * 100).round(1)
  text += "| [#{langs_fmt[lang]}](#{lang}) | #{count} | #{total_percent}% |\n"
end

text += %(
## Solved problems

List of solved problems with links to the solutions in different languages (helps with comparing the implementations).

| Problem name | Languages |
| --- | --- |
)

problems.sort.each do |problem, langs|
  problem_name = problem.split('-').map(&:capitalize).join(' ')
  links = langs.sort.map { |l| "[#{langs_fmt[l]}](#{l}/#{problem})" }.join(', ')

  text += "| #{problem_name} | #{links} |\n"
end

text += %(
## Contributions

This repository serves as a personal collection of my own solutions. However, if you find any issues
or have suggestions for improvements, feel free to open an issue or submit a pull request.
Contributions from the community are always welcome!
)

File.write('README.md', text)
