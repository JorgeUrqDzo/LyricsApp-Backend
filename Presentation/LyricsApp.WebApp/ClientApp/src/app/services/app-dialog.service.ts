import { Injectable } from '@angular/core';

interface DialogOptions {
  height?: string;
  width?: string;
  disableClose?: boolean;
  data?: any;
}

@Injectable({
  providedIn: 'root',
})
export class AppDialogService {

  constructor(private dialog: MatDialog) {}
}
