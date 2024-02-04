import { Component } from '@angular/core';
import {
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { AppDialogService } from 'src/app/services/app-dialog.service';
import { SecurityService } from 'src/app/services/security.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginForm = new FormBuilder().group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });
  get form() {
    return this.loginForm.controls
  }
  submitted = false;

  constructor(
    private _service: SecurityService,
    private _dialog: AppDialogService
  ) {}

  doLogin() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this._dialog.loadingShow();
    const data = this.loginForm.value;

    this._service.doLogin(data.username!, data.password!).subscribe({
      next: (res) => {
        console.log(res);
        this._dialog.loadingHide();
        if (res && res.success) {
          this._service.setAccessToken(res.model);
        }
      },
      error: (err) => {
        this._dialog.loadingHide();
        const errorMessage = JSON.parse(err.error.message)['error_description'];
        if (errorMessage) {
          this._dialog.show('Login error', errorMessage);
        } else {
          this._dialog.show('Login error', 'Something went wrong.');
        }
      },
    });
  }
}
