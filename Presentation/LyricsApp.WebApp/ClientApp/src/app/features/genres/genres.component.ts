import { Component, OnInit } from '@angular/core';
import { PaginationComponent } from 'src/app/components/pagination/pagination.component';
import { PaginationModel } from 'src/app/models/PaginationModel';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { GenreFormComponent } from './genre-form/genre-form.component';
import { GenresService } from 'src/app/services/genres.service';
import { GenreModel } from 'src/app/models/Genre';

@Component({
  selector: 'app-genres',
  standalone: true,
  imports: [PaginationComponent],
  templateUrl: './genres.component.html',
  styleUrl: './genres.component.css',
})
export class GenresComponent implements OnInit {
  genres: GenreModel[] = [];

  constructor(
    private dialog: AppDialogService,
    private _genresService: GenresService
  ) {}

  ngOnInit(): void {
    this.loadGenres();
  }

  private loadGenres() {
    this.dialog.loadingShow();
    this._genresService.getGenres().subscribe({
      next: (res) => {
        if (res.success) {
          this.genres = res.model;
        }
        this.dialog.loadingHide();
      },
      error: (err) => {
        console.log('err :>> ', err);
        this.dialog.loadingHide();
      },
    });
  }

  confirmDelete(genre: GenreModel) {
    this.dialog
      .confirmDelete(
        'Delete Genre',
        `Are you sure you want to delete this genre: ${genre.name} ?`
      )
      .subscribe((res) => {
        if (res) {
          this.dialog.loadingShow();
          this._genresService.deleteGenre(genre.id!).subscribe({
            next: (res) => {
              const index = this.genres.findIndex((x) => x.id == genre.id);
              if (index > -1) {
                this.genres.splice(index, 1);
              }
              this.dialog.loadingHide();
              this.dialog.show('Delete Genre', 'Genre successfully deleted.');
            },
            error: (err) => {
              console.log('err :>> ', err);
              this.dialog.loadingHide();
            },
          });
        }
      });
  }
  newGenre() {
    this.dialog
      .showComponent(GenreFormComponent, {
        width: '500px',
        disableClose: true,
      })
      .subscribe((res) => {
        if (res) {
          this.dialog.loadingShow();
          this._genresService.createGenre(res).subscribe({
            next: (data) => {
              this.genres.push(data.model);
              this.dialog.loadingHide();
            },
            error: (err) => {
              console.log('err :>> ', err);
              this.dialog.loadingHide();
            },
          });
        }
      });
  }

  editGenre(genre: GenreModel) {
    this.dialog
      .showComponent(GenreFormComponent, {
        width: '500px',
        disableClose: true,
        data: {
          genre: genre,
        },
      })
      .subscribe((res) => {
        if (res) {
          this.dialog.loadingShow();
          this._genresService.updateGenre(res.id, res).subscribe({
            next: (data) => {
              const index = this.genres.findIndex((x) => x.id == res.id);
              if (index > -1) {
                this.genres[index] = res;
              }
              this.dialog.loadingHide();
            },
            error: (err) => {
              console.log('err :>> ', err);
              this.dialog.loadingHide();
            },
          });
        }
      });
  }
}
