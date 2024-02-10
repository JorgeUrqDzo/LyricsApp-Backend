import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { GenreModel } from 'src/app/models/Genre';
import { SongModel } from 'src/app/models/Song';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-song-form',
  standalone: true,
  imports: [MatDialogModule, ReactiveFormsModule, FormsModule],
  templateUrl: './song-form.component.html',
  styleUrl: './song-form.component.css',
})
export class SongFormComponent implements OnInit {
  genres: GenreModel[] = [];

  form = new FormBuilder().group({
    id: [''],
    title: ['', Validators.required],
    lyric: [''],
    genreId: [null],
  });

  get f() {
    return this.form.controls;
  }

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<SongFormComponent>
  ) {
    if (data && data['genres']) {
      this.genres = data['genres'];
    }

    if (data && data['song']) {
      this.form.patchValue(data['song']);
      this.form.controls.genreId.setValue(data['song'].genre.id)
    }
  }

  ngOnInit(): void {}

  onSubmit() {
    if (this.form.invalid) {
      return;
    }
    const data: SongModel = this.form.value;
    this.dialogRef.close(data);
  }
}
