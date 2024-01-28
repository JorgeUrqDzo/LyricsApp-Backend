import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-app-dialog',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './app-dialog.component.html',
  styleUrl: './app-dialog.component.css',
})
export class AppDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
}
