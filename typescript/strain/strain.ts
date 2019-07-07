function keep<T>(xs: T[], predicate: (e: T) => boolean): T[] {
  return xs.filter((x) => predicate(x))
}

function discard<T>(xs: T[], predicate: (e: T) => boolean): T[] {
  return xs.filter((x) => !predicate(x))
}

export { keep, discard }