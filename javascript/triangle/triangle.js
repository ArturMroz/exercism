function Triangle(a, b, c) {
  this.a = a;
  this.b = b;
  this.c = c;
}

Triangle.prototype.kind = function kind() {
  if (this.a <= 0 || this.b <= 0 || this.c <= 0) {
    throw new Error('Edge has to be bigger than 0.');
  }
  if ((this.a + this.b < this.c) || this.a + this.c < this.b || this.b + this.c < this.a) {
    throw new Error('Illegal triangle.');
  }
  if (this.a === this.b && this.b === this.c && this.a === this.c) {
    return 'equilateral';
  }
  if (this.a === this.b || this.b === this.c || this.c === this.a) {
    return 'isosceles';
  }

  return 'scalene';
};

module.exports = Triangle;