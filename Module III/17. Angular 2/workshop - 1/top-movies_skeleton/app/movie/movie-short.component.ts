import { Component, Input } from '@angular/core';

import { Movie } from '../core/models/movie';

@Component({
  selector: '[mvdb-movie-short]',
  template: `
    <td><img src="{{ poster }}"></td>
    <td>{{ title }}</td>
    <td>{{ releaseYear }}</td>
    <td>{{ imdbRating | number: '1.1-1' }}</td>
  `,
  styles: [`
    td {
      padding: 10px;
      margin-top: 10px;
      border-top: 2px solid #c1c1c1;
      vertical-align: top;
      text-align: left;
    }
    td>img {
      height: 25%;
    }
  `]
})
export class MovieShortComponent {
  @Input() movie: Movie;

  get title(): string {
    return this.movie.title;
  }

  get poster(): string {
    return this.movie.posterSrc;
  }

  get releaseYear(): number {
    return this.movie.releaseDate.getFullYear();
  }

  get imdbRating(): number {
    return this.movie.imdbRating;
  }
}