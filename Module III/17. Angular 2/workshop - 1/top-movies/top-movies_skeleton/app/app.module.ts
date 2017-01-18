import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { MoviesListComponent } from './core/movies/movies-list.component';
import { MovieComponent } from './core/movies/movie.component';
import { FilterPipe } from './core/pipes/filter-pipe';

import { Ng2BootstrapModule } from 'ng2-bootstrap/ng2-bootstrap';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        MoviesListComponent,
        MovieComponent,

        FilterPipe
    ],
    imports: [
        BrowserModule,
        HttpModule,
        Ng2BootstrapModule
    ],
    providers: [
    ]
})
export class AppModule { }
