export default class Triangle {
  constructor(...edges) {
    this.edges = edges;
  }

  kind() {
    const [a, b, c] = this.edges;

    if (a <= 0 || b <= 0 || c <= 0) {
      throw new Error('Edge has to be bigger than 0.');
    }

    if (a + b <= c || a + c <= b || b + c <= a) {
      throw new Error('Illegal triangle.');
    }

    if (a === b && b === c) {
      return 'equilateral';
    }

    if (a === b || b === c || c === a) {
      return 'isosceles';
    }

    return 'scalene';
  }
}