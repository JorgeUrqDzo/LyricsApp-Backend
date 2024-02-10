import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PaginationComponent } from 'src/app/components/pagination/pagination.component';
import {
  PagedResultBase,
  PaginationModel,
} from 'src/app/models/PaginationModel';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { SongFormComponent } from './song-form/song-form.component';
import { SongsService } from 'src/app/services/songs.service';
import { SongModel } from 'src/app/models/Song';
import { GenresService } from 'src/app/services/genres.service';
import { forkJoin } from 'rxjs';
import { GenreModel } from 'src/app/models/Genre';

@Component({
  selector: 'app-songs',
  standalone: true,
  imports: [CommonModule, PaginationComponent],
  templateUrl: './songs.component.html',
  styleUrl: './songs.component.css',
})
export class SongsComponent implements OnInit {
  pagination: PagedResultBase = {
    currentPage: 1,
    pages: 1,
    pageSize: 1,
    totalRecords: 0,
  };
  songs: SongModel[] = [];
  genres: GenreModel[] = [];
  loadingFavorite = '';

  constructor(
    private dialog: AppDialogService,
    private _songsService: SongsService,
    private _genresService: GenresService
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  changePageEvent($event: number) {
    console.log('page change:', $event);
  }

  setFavorite(id: string, isFavorite: boolean) {
    this.loadingFavorite = id;

    this._songsService.setFavorite(id, isFavorite).subscribe({
      next: (res) => {
        console.log('res :>> ', res);

        const index = this.songs.findIndex((x) => x.id == res.model.id);
        if (index > -1) {
          this.songs[index].isFavorite = res.model.isFavorite;
        }

        this.loadingFavorite = '';
      },
      error: (err) => {
        this.loadingFavorite = '';
      },
    });
  }

  newSong() {
    this.dialog
      .showComponent(SongFormComponent, {
        width: '800px',
        disableClose: true,
        data: {
          genres: this.genres,
        },
      })
      .subscribe((res) => {
        if (res) {
          this.dialog.loadingShow();
          this._songsService.create(res).subscribe({
            next: (data) => {
              this.songs.push(data.model);
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

  editSong(song: SongModel) {
    this.dialog
      .showComponent(SongFormComponent, {
        width: '800px',
        disableClose: true,
        data: {
          genres: this.genres,
          song: song,
        },
      })
      .subscribe((res) => {
        if (res) {
          this.dialog.loadingShow();
          this._songsService.update(res.id, res).subscribe({
            next: (data) => {
              const index = this.songs.findIndex((x) => x.id == res.id);
              if (index > -1) {
                const selectedGenre = this.genres.find(
                  (x) => x.id === res.genreId
                );
                res.genre = selectedGenre;
                this.songs[index] = res;
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

  confirmDelete(song: SongModel) {
    this.dialog
      .confirmDelete(
        'Delete Song',
        `Are you sure you want to delete this song: ${song.title} ?`
      )
      .subscribe((res) => {
        if (res) {
          this.dialog.loadingShow();
          this._songsService.delete(song.id!).subscribe({
            next: (res) => {
              const index = this.songs.findIndex((x) => x.id == song.id);
              if (index > -1) {
                this.songs.splice(index, 1);
              }
              this.dialog.loadingHide();
              this.dialog.show('Delete Song', 'Song successfully deleted.');
            },
            error: (err) => {
              console.log('err :>> ', err);
              this.dialog.loadingHide();
            },
          });
        }
      });
  }

  private loadData() {
    this.dialog.loadingShow();

    forkJoin({
      songs: this._songsService.get(),
      genres: this._genresService.getGenres(),
    }).subscribe({
      next: (data) => {
        if (data.songs.success) {
          this.songs = data.songs.model.results;
          this.pagination = data.songs.model;
        }

        if (data.genres.success) {
          this.genres = data.genres.model;
        }

        this.dialog.loadingHide();
      },
      error: (err) => {
        console.log('err :>> ', err);
        this.dialog.loadingHide();
      },
    });
  }
}
