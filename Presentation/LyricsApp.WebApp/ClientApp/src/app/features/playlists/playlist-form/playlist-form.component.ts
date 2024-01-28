import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-playlist-form',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './playlist-form.component.html',
  styleUrl: './playlist-form.component.css',
})
export class PlaylistFormComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
}
