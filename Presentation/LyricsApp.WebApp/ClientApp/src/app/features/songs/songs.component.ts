import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PaginationComponent } from 'src/app/components/pagination/pagination.component';
import { PagedResultBase } from 'src/app/models/PaginationModel';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { SongsService } from 'src/app/services/songs.service';
import { SongModel } from 'src/app/models/Song';
import { RouterModule } from '@angular/router';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-songs',
  standalone: true,
  imports: [CommonModule, PaginationComponent, RouterModule, ReactiveFormsModule],
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
  loadingFavorite = '';

  form = new FormBuilder().group({
    title: [''],
  });

  get f() {
    return this.form.controls;
  }

  constructor(
    private dialog: AppDialogService,
    private _songsService: SongsService
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

  search() {

    this.dialog.loadingShow();
    const title  = this.form.value.title ?? '';
    this._songsService.get(title).subscribe({
      next: (data) => {
        if (data.success) {
          this.songs = data.model.results;
          this.pagination = data.model;
        }
        this.dialog.loadingHide();
      },
      error: (err) => {
        console.log('err :>> ', err);
        this.dialog.loadingHide();
      },
    });
  }

  private loadData() {
    this.dialog.loadingShow();
    this._songsService.get().subscribe({
      next: (data) => {
        if (data.success) {
          this.songs = data.model.results;
          this.pagination = data.model;
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
