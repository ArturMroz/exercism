const DnaTranscriber = function () {};
DnaTranscriber.prototype.mapping = {
  'G': 'C',
  'C': 'G',
  'T': 'A',
  'A': 'U'
}

DnaTranscriber.prototype.toRna = function (dna) {
  if (dna.match(/[^GCTA]/)) {
    throw new Error('Invalid input');
  } else {
    return dna.split('').map(nucleotide => this.mapping[nucleotide]).join('');
  }
};

module.exports = DnaTranscriber;