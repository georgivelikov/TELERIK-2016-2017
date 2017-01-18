import { Component, Input } from '@angular/core';

@Component({
    selector: '[mvdb-movie-short]',
    templateUrl: './movie.component.html',
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
export class MovieComponent {
    title: String;
    poster: String;
    year: Number;
    imdbRating: Number;

    @Input('movie') set movie(movie: any) {
        this.title = movie.Title;
        this.poster = movie.Poster;
        this.year = movie.Year;
        this.imdbRating = movie.imdbRating;
    }
}
