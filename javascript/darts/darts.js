export const solve = (x, y) => {
  if (isNaN(x) || isNaN(y)) return null;

  const furthest = Math.max(x, y);

  if (furthest > 10) return 0;
  if (furthest > 5) return 1;
  if (furthest > 1) return 5;
  return 10;
};