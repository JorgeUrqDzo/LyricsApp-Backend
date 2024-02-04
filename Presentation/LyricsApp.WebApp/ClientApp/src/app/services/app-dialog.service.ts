import { ComponentType } from '@angular/cdk/portal';
import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AppDialogComponent } from '../components/app-dialog/app-dialog.component';
import { AppConfirmDialogComponent } from '../components/app-confirm-dialog/app-confirm-dialog.component';
import { Observable } from 'rxjs';
import { AppLoadingComponent } from '../components/app-loading/app-loading.component';
import { NgxSpinnerService } from 'ngx-spinner';

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
  private _loading?: MatDialogRef<AppLoadingComponent>;

  constructor(private dialog: MatDialog, private spinner: NgxSpinnerService) {}

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

  public loadingShow(message?: string): MatDialogRef<AppLoadingComponent> {
    let dialogRef: MatDialogRef<AppLoadingComponent>;
    this.spinner.show();
    dialogRef = this.dialog.open(AppLoadingComponent, {
      width: '380px',
      disableClose: true,
      panelClass: 'dialog-panel',
      data: { message },
    });
    dialogRef.afterClosed().subscribe((_) => {
      this.spinner.hide();
    });
    this._loading = dialogRef;
    return dialogRef;
  }

  public loadingHide() {
    if (this._loading) {
      this._loading.close();
      this._loading = undefined;
    }
  }
}
