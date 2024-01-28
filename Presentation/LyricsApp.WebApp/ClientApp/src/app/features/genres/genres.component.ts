import { Component } from '@angular/core';
import { PaginationComponent } from 'src/app/components/pagination/pagination.component';
import { PaginationModel } from 'src/app/models/PaginationModel';

@Component({
  selector: 'app-genres',
  standalone: true,
  imports: [PaginationComponent],
  templateUrl: './genres.component.html',
  styleUrl: './genres.component.css',
})
export class GenresComponent {
  pagination: PaginationModel = {
    currentPage: 1,
    pages: 4,
    pageSize: 100,
    totalRecords: 400,
  };

  changePageEvent($event: number) {
    console.log('page change:', $event);
  }
}
