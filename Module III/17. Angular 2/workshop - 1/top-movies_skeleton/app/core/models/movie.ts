export class Movie {
  public title: string;
  public posterSrc: string;
  public releaseDate: Date;
  public imdbRating: number;

  constructor(
    title: string,
    posterSrc: string,
    releaseDate: Date,
    imdbRating: number) {

    this.title = title;
    this.posterSrc = posterSrc;
    this.releaseDate = releaseDate;
    this.imdbRating = imdbRating;
  }
}