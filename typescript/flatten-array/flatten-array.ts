class FlattenArray {
  static flatten<T>(xs: T[]): T[] {
    return xs.reduce((acc: T[], x: T) =>
      Array.isArray(x)
        ? [...acc, ...this.flatten(x)]
        : x !== undefined
          ? [...acc, x]
          : acc
      , [])
  }
}

export default FlattenArray