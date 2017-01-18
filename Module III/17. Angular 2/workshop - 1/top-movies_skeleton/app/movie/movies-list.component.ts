import { Component, Inject, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Movie } from '../core/models/movie';

@Component({
  selector: 'movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {
  private http: Http;
  private sortedBy: string;
  private listOrder: string;
  private searchPattern: string;

  public pageTitle: string;
  public movies: any[];

  constructor(http: Http) {
    this.http = http;

    this.pageTitle = 'Top 10 iMDB Movies';
    this.movies = [];
  }

  ngOnInit(): void {
    this.http.get('../data/movies.json')
      .map((res: Response) => res.json()
        .map((movie: any) => {
          let { Title, Poster, Released, imdbRating } = movie;
          let releaseDate: Date = new Date(Released);

          return new Movie(Title, Poster, releaseDate, imdbRating);
        }))
      .subscribe((movies: Movie[]) => this.movies.push(...movies));
  }
}