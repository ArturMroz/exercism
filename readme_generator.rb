fmt_lang = {
  'clojure'    => 'Clojure',
  'csharp'     => 'C#',
  'elm'        => 'Elm',
  'emacs-lisp' => 'Elisp',
  'fsharp'     => 'F#',
  'go'         => 'Go',
  'javascript' => 'JavaScript',
  'python'     => 'Python',
  'ruby'       => 'Ruby',
  'rust'       => 'Rust',
  'typescript' => 'TypeScript',
}

problems_hash = Hash.new { [] }

Dir['*/*'].each do |dir|
  lang, problem = dir.split('/')
  problems_hash[problem] = problems_hash[problem].push(lang)
end

text = %q(
# Exercism.io solutions

> You should not have a favourite weapon. To become over-familiar with one weapon is as much a fault as not knowing it sufficiently well.
>
> ― Miyamoto Musashi, The Book of Five Rings


My solutions to [exercism.io](https://exercism.io) problems using various languages. For fun and profit.

## Solved problems

This table lists solved problems and conviniently links to the solutions in different languages, making it easy to compare the implementations.

| Problem name | Languages |
| --- | --- |
)

problems_hash.sort.each do |problem, langs|
  problem_name = problem.split('-').map(&:capitalize).join(' ')
  links = langs.sort.map { |l| "[#{fmt_lang[l]}](tree/master/#{l}/#{problem})" }.join(', ')

  text += "| #{problem_name} | #{links} |\n"
  File.write('README.md', text)
end
