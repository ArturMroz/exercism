function keep<T>(xs: T[], fn: (el: T) => boolean): T[] {
  return xs.filter((x) => fn(x))
}

function discard<T>(xs: T[], fn: (el: T) => boolean): T[] {
  return xs.filter((x) => !fn(x))
}

export { keep, discard }