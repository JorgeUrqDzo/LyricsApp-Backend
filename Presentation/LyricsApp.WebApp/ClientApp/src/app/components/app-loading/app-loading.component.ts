import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { NgxSpinnerModule } from 'ngx-spinner';

@Component({
  selector: 'app-app-loading',
  standalone: true,
  imports: [MatDialogModule, NgxSpinnerModule],
  templateUrl: './app-loading.component.html',
  styleUrl: './app-loading.component.css',
})
export class AppLoadingComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data?: any) {}
}
