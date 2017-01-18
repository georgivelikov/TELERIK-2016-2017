import { Http, Response, } from '@angular/http';
import { Component, OnInit } from '@angular/core';
import { MovieComponent } from './movie.component';

@Component({
    selector: 'movies-list',
    templateUrl: './movies-list.component.html',
    styles: [`
        table {
            margin: 15px auto;
        },
        tbody>tr:hover {
            background-color: #f2f2f2;
            cursor: pointer;
        },
        thead>tr>th {
            padding: 10px;
        }

        .search-container {
            width: 350px;

            margin: 0px 400px;
            text-align: center;
        }

        .sort-order-container {
            width: 350px;

            margin: 0px 400px;
            text-align: center;
        }

        .sort-order-container>div {
            display: inline-block;
            width: 45%;
            text-align: left;
        }

        .sort-order-container>div:first-child {
            margin-right: 10px;
        }
    `]
})
export class MoviesListComponent implements OnInit {
    movies: MovieComponent[];
    http: Http;

    constructor(http: Http) {
        this.http = http;
        this.movies = [];
    }

    ngOnInit(): void {
        this.http.get('../../data/movies.json')
        .map((res: Response) => res.json())
        .subscribe(
            foundMovies => this.movies = foundMovies
        );
    }
}