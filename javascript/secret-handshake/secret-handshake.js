export const secretHandshake = (number) => {
  if (isNaN(number)) throw new Error('Handshake must be a number');

  const conditions = [ 
    { val: 0b1, text: 'wink' },
    { val: 0b10, text: 'double blink' },
    { val: 0b100, text: 'close your eyes' },
    { val: 0b1000, text: 'jump' },
  ];

  const isReverse = 0b10000;
  const seq = []

  conditions.forEach(c => {
    if (c.val & number) seq.push(c.text)
  });

  if (isReverse & number) seq.reverse();

  return seq;
};