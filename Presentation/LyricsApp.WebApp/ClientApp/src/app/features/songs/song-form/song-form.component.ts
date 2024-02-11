import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Observable, forkJoin, of } from 'rxjs';
import { GenreModel } from 'src/app/models/Genre';
import { ApiSuccess } from 'src/app/models/ResponseModel';
import { SongModel } from 'src/app/models/Song';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { GenresService } from 'src/app/services/genres.service';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-song-form',
  standalone: true,
  imports: [MatDialogModule, ReactiveFormsModule, FormsModule, RouterModule],
  templateUrl: './song-form.component.html',
  styleUrl: './song-form.component.css',
})
export class SongFormComponent implements OnInit {
  genres: GenreModel[] = [];

  form = new FormBuilder().group({
    id: [''],
    title: ['', Validators.required],
    lyric: [''],
    genreId: [''],
  });

  get f() {
    return this.form.controls;
  }

  private _id: string | null;
  title = 'Edit';
  song: SongModel | undefined;
  submitted = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dialog: AppDialogService,
    private _songsService: SongsService,
    private _genresService: GenresService
  ) {
    this._id = this.route.snapshot.queryParams['id'];

    if (!this._id) {
      this.title = 'Create';
    }

    this.loadData();
  }

  ngOnInit(): void {}

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      this.dialog.show(`${this.title} Song`, 'Invalid form values.');
      return;
    }
    const data: SongModel = this.form.value;
    if (this._id) {
      this.editSong(data);
    } else {
      this.createSong(data);
    }
    this.submitted = false;
  }

  private editSong(song: SongModel) {
    this.dialog.loadingShow();
    if (this._id) {
      this._songsService.update(song.id!, song).subscribe({
        next: (data) => {
          this.dialog.loadingHide();
          this.dialog
            .confirm(
              'Edit Song',
              'Your song changes has been saved successfully. Do you want to continue editing?'
            )
            .subscribe((res) => {
              if (!res) {
                this.router.navigate(['/songs']);
              }
            });
        },
        error: (err) => {
          console.log('err :>> ', err);
          this.dialog.loadingHide();
        },
      });
    }
  }

  private createSong(song: SongModel) {
    this.dialog.loadingShow();
    this._songsService.create(song).subscribe({
      next: (data) => {
        this.dialog.loadingHide();
        this.form.reset();
        this.form.controls.genreId.setValue('');
        this.dialog.show('Create Song', 'The song was created.');
      },
      error: (err) => {
        console.log('err :>> ', err);
        this.dialog.loadingHide();
      },
    });
  }

  private loadGenres(): Observable<ApiSuccess<GenreModel[]>> {
    return this._genresService.getGenres();
  }
  private loadSong(): Observable<ApiSuccess<SongModel>> {
    if (this._id) {
      return this._songsService.getById(this._id!);
    }

    const result: ApiSuccess<SongModel> = {
      message: '',
      model: {},
      success: false,
    };

    return of(result);
  }

  private loadData() {
    this.dialog.loadingShow();

    forkJoin({
      genres: this.loadGenres(),
      songs: this.loadSong(),
    }).subscribe({
      next: (data) => {
        if (data.genres.success) {
          this.genres = data.genres.model;
        }

        if (data.songs.success) {
          const song = data.songs.model;
          this.form.patchValue({
            id: song.id,
            genreId: song?.genre?.id ?? '',
            lyric: song.lyric,
            title: song.title,
          });
        }

        this.dialog.loadingHide();
      },
      error: (err) => {
        console.log('err :>> ', err);
        this.dialog.loadingHide();
        this.dialog.show('Error', err.error.message).subscribe((res) => {
          this.router.navigate(['/songs/']);
        });
      },
    });
  }
}
