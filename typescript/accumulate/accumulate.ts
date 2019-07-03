function accumulate<T>(collection: T[], fn: (n: T) => {}) {
  return collection.map((el) => fn(el))
}

export default accumulate