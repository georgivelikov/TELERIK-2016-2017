import { PipeTransform, Pipe } from '@angular/core';
import { Movie } from '../core/models/movie';

@Pipe({
  name: 'movieFilter'
})
export class MovieFilterPipe implements PipeTransform {
  transform(value: Movie[], filterBy: string, listOrder: string, sortedBy: string): Movie[] {
    if (filterBy) {
      filterBy = filterBy.toLocaleLowerCase();
      value = value.filter((movie: Movie) => movie.title.toLocaleLowerCase().includes(filterBy));
    }

    listOrder = listOrder || 'ascending';
    sortedBy = sortedBy || 'title';

    value = value.sort((a: any, b: any) => {
      a = a[sortedBy];
      b = b[sortedBy];

      a = (a.toLocaleLowerCase && a.toLocaleLowerCase()) || (a.getFullYear && a.getFullYear()) || a;
      b = (b.toLocaleLowerCase && b.toLocaleLowerCase()) || (b.getFullYear && b.getFullYear()) || b;

      if (b < a) {
        return listOrder == 'ascending' ? 1 : - 1;
      }
      else if (a < b) {
        return listOrder == 'ascending' ? -1 : 1;
      }

      return 0;
    });

    return value;
  }
}