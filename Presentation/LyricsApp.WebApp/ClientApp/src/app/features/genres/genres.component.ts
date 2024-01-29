import { Component } from '@angular/core';
import { PaginationComponent } from 'src/app/components/pagination/pagination.component';
import { PaginationModel } from 'src/app/models/PaginationModel';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { GenreFormComponent } from './genre-form/genre-form.component';

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

  constructor(private dialog: AppDialogService) {}

  confirmDelete() {
    this.dialog
      .confirmDelete('Delete Genre', 'Are you sure you want to delete this genre?',)
      .subscribe((res) => {
        if (res) {
          this.dialog.show('Delete Genre', 'Genre successfully deleted.');
        }
      });
  }
  newGenre() {
    this.dialog.showComponent(GenreFormComponent, {
      width: '500px',
      disableClose: true,
    });
  }

  editGenre(genre: any) {
    this.dialog.showComponent(GenreFormComponent, {
      width: '500px',
      disableClose: true,
      data: {},
    });
  }

  changePageEvent($event: number) {
    console.log('page change:', $event);
  }
}
