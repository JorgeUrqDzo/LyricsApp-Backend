import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ApiSuccess } from '../models/ResponseModel';
import { AuthResponseModel } from '../models/AuthResponseModel';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class SecurityService {

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient,
    private router: Router
  ) {
    console.log(baseUrl);
  }

  doLogin(username: string, password: string) {
    return this.http.post<ApiSuccess<AuthResponseModel>>(this.baseUrl + 'api/auth/LoginWithEmailAndPassword', {
      email: username,
      password: password,
    });
  }

  setAccessToken(data: AuthResponseModel) {
    localStorage.setItem("LyricsToken", data.accessToken);
    localStorage.setItem("LyricsRefreshToken", data.refreshToken);
    localStorage.setItem("LyricsDisplayName", data.displayName);
    localStorage.setItem("LyricsUserId", data.userId);

    this.router.navigateByUrl("/home");
  }
}


