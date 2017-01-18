import { Pipe, PipeTransform } from '@angular/core';
import { MovieComponent } from '../movies/movie.component';

@Pipe({ name: 'filter' })

export class FilterPipe implements PipeTransform {
    transform(values: any[], filterBy: string, listOrder: string, sortedBy: string): any[] {
        if (filterBy) {
            filterBy = filterBy.toLocaleLowerCase();
            values = values.filter((movie: any) => movie['Title'].toLocaleLowerCase().includes(filterBy));
        }

        listOrder = listOrder || 'ascending';
        sortedBy = sortedBy || 'title';

        if (sortedBy === 'title') {
            return this.sortByTitle(values, listOrder);
        } else if (sortedBy === 'imdbRating') {
            return this.sortByRating(values, listOrder);
        } else {
            return this.sortByYear(values, listOrder);
        }
    }

    sortByTitle(values: any[], listOrder: string) {
        values = values.sort((a: any, b: any) => {
            console.log(a);
            let firstTitle = a['Title'].toLocaleLowerCase();
            let secondTitle = b['Title'].toLocaleLowerCase();

            if (secondTitle < firstTitle) {
                return listOrder === 'ascending' ? 1 : - 1;
            } else if (firstTitle < secondTitle) {
                return listOrder === 'ascending' ? -1 : 1;
            }

            return 0;
        });

        return values;
    }

    sortByRating(values: any[], listOrder: string) {
        values = values.sort((a: any, b: any) => {

            let firstRating = a['imdbRating'];
            let secondRating = b['imdbRating'];

            if (secondRating < firstRating) {
                return listOrder === 'ascending' ? 1 : - 1;
            } else if (firstRating < secondRating) {
                return listOrder === 'ascending' ? -1 : 1;
            }

            return 0;
        });

        return values;
    }

    sortByYear(values: any[], listOrder: string) {
        values = values.sort((a: any, b: any) => {

            let firstYear = a['Year'];
            let secondYear = b['Year'];

            if (secondYear < firstYear) {
                return listOrder === 'ascending' ? 1 : - 1;
            } else if (firstYear < secondYear) {
                return listOrder === 'ascending' ? -1 : 1;
            }

            return 0;
        });

        return values;
    }
}
