import { ComponentType } from '@angular/cdk/portal';
import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AppDialogComponent } from '../components/app-dialog/app-dialog.component';
import { AppConfirmDialogComponent } from '../components/app-confirm-dialog/app-confirm-dialog.component';
import { Observable } from 'rxjs';

interface DialogOptions {
  height?: string;
  width?: string;
  disableClose?: boolean;
  data?: any;
  panelClass?: string;
}

@Injectable({
  providedIn: 'root',
})
export class AppDialogService {
  constructor(private dialog: MatDialog) {}

  public show(title: string, message: string) {
    let dialogRef: MatDialogRef<AppDialogComponent>;
    dialogRef = this.dialog.open(AppDialogComponent, {
      width: '380px',
      disableClose: true,
      panelClass: 'dialog-panel',
      data: { title, message },
    });

    return dialogRef.afterClosed();
  }

  public showComponent<T>(
    component: ComponentType<T>,
    options?: DialogOptions
  ) {
    if (options) {
      options.panelClass = 'dialog-panel';
    } else {
      options = {
        width: '380px',
        disableClose: true,
        panelClass: 'dialog-panel',
      };
    }

    return this.dialog.open(component, options).afterClosed();
  }

  public confirm(title: string, message: string): Observable<boolean> {
    let dialogRef: MatDialogRef<AppConfirmDialogComponent>;
    dialogRef = this.dialog.open(AppConfirmDialogComponent, {
      width: '380px',
      disableClose: true,
      panelClass: 'dialog-panel',
      data: { title, message },
    });
    return dialogRef.afterClosed();
  }

  public confirmDelete(title: string, message: string): Observable<boolean> {
    let dialogRef: MatDialogRef<AppConfirmDialogComponent>;
    dialogRef = this.dialog.open(AppConfirmDialogComponent, {
      width: '380px',
      disableClose: true,
      panelClass: 'dialog-panel',
      backdropClass: 'dialog-backdrop',
      data: { title, message, confirmDelete: true },
    });
    return dialogRef.afterClosed();
  }
}
