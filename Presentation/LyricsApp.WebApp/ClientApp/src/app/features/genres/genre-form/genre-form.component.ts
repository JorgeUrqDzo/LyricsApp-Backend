import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './genre-form.component.html',
  styleUrl: './genre-form.component.css',
})
export class GenreFormComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
}
