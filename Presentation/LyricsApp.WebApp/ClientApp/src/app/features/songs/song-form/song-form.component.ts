import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-song-form',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './song-form.component.html',
  styleUrl: './song-form.component.css',
})
export class SongFormComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
}
