import { Component, Inject } from '@angular/core';
import {
  FormBuilder,
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

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [MatDialogModule, FormsModule, ReactiveFormsModule],
  templateUrl: './genre-form.component.html',
  styleUrl: './genre-form.component.css',
})
export class GenreFormComponent {
  form = new FormBuilder().group({
    id: [''],
    name: ['', Validators.required],
  });

  get f() {
    return this.form.controls;
  }

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<GenreFormComponent>
  ) {
    if (data['genre']) {
      this.form.patchValue(data['genre']);
    }
  }

  onSubmit() {
    if (this.form.invalid) {
      return;
    }
    const data: GenreModel = this.form.value;
    this.dialogRef.close(data);
  }
}
