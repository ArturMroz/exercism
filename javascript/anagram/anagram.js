export default class Anagram {
  constructor(str) {
    this.text = str.toLowerCase();
  }

  matches(arr) {
    return arr.filter((el) => {
      if (this.text.length !== el.length) return false;

      if (this.text === el.toLowerCase()) return false;

      const sorted = this.text.split('').sort().join('');
      return sorted === el.toLowerCase().split('').sort().join('');
    });
  }
}