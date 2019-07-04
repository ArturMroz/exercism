function accumulate<T, U>(collection: T[], fn: (n: T) => U): U[] {
  return collection.map((el) => fn(el))
}

export default accumulate