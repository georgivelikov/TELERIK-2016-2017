import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, Response } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { Ng2BootstrapModule } from 'ng2-bootstrap/ng2-bootstrap';

import { AppComponent } from './app.component';
import { MovieFilterPipe } from './movie/movie-filter.pipe';
import { MovieShortComponent } from './movie/movie-short.component';
import { MoviesListComponent } from './movie/movies-list.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  declarations: [
    AppComponent,
    MovieFilterPipe,
    MovieShortComponent,
    MoviesListComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }