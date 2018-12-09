export const isPangram = (str) => {
  const alphabet = "abcdefghijklmnopqrstuvwxyz";

  // method 1
  // const stripped = str.toLowerCase().replace(/[^a-z]/g, '');
  // const sorted = [...(new Set(stripped))].sort().join('')
  // return alphabet === sorted;

  // method 2
  const lowerCased = str.toLowerCase();
  return alphabet.split('').every(ch => lowerCased.includes(ch));
};