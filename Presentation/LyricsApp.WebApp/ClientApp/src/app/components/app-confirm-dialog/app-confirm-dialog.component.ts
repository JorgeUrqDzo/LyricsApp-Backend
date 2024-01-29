import { NgClass } from '@angular/common';
import { Component, Inject } from '@angular/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';

interface DialgoConfirmData {
  confirmDelete: boolean;
  title: string;
  message: string;
}

@Component({
  selector: 'app-app-confirm-dialog',
  standalone: true,
  imports: [MatDialogModule, NgClass],
  templateUrl: './app-confirm-dialog.component.html',
  styleUrl: './app-confirm-dialog.component.css',
})
export class AppConfirmDialogComponent {
  cancelColor: Record<string, boolean> = {};
  okColor: Record<string, boolean> = {};

  constructor(
    public dialogRef: MatDialogRef<AppConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialgoConfirmData
  ) {
    this.setClasses();
  }

  setClasses() {
    if (this.data) {
      this.cancelColor = {
        'text-error': !this.data.confirmDelete,
      };

      this.okColor = {
        'text-error': this.data.confirmDelete,
        'text-primary': !this.data.confirmDelete,
      };
    }
  }
}
