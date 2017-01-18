import { Component } from '@angular/core';

@Component({
    selector: 'mvdb-app',
    templateUrl: './app.component.html',
    styles: [`
        .search-container {
            text-align: left;
            width: 50%;
            margin: 0 auto;
        }

        #search {
            width: 100%;
        }

        .container {
            text-align: center;
        }
    `]
})
export class AppComponent {}
