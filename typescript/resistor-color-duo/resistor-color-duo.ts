export class ResistorColor {
  private colors: string[];

  private allColors: string[] = [
    "black",
    "brown",
    "red",
    "orange",
    "yellow",
    "green",
    "blue",
    "violet",
    "grey",
    "white",
  ];

  constructor(colors: string[]) {
    if (colors.length < 2)
      throw "At least two colors need to be present"

    this.colors = colors.slice(0, 2);
  }

  value = (): number => {
    return this.allColors.indexOf(this.colors[0]) * 10
      + this.allColors.indexOf(this.colors[1]);
  };
}
