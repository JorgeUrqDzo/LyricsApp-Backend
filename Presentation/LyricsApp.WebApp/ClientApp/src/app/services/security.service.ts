import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ApiSuccess } from '../models/ResponseModel';
import { AuthResponseModel } from '../models/AuthResponseModel';
import { Router } from '@angular/router';
import { BehaviorSubject, lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SecurityService {
  private isAuth = new BehaviorSubject<boolean>(false);

  getIsAuth() {
    return this.isAuth.value;
  }

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient,
    private router: Router
  ) {}

  doLogin(username: string, password: string) {
    return this.http.post<ApiSuccess<AuthResponseModel>>(
      this.baseUrl + 'api/auth/LoginWithEmailAndPassword',
      {
        email: username,
        password: password,
      }
    );
  }

  logout() {
    localStorage.removeItem('LyricsToken');
    localStorage.removeItem('LyricsRefreshToken');
    localStorage.removeItem('LyricsDisplayName');
    localStorage.removeItem('LyricsUserId');
    this.isAuth.next(false);
  }

  setAccessToken(data: AuthResponseModel) {
    localStorage.setItem('LyricsToken', data.accessToken);
    localStorage.setItem('LyricsRefreshToken', data.refreshToken);
    localStorage.setItem('LyricsDisplayName', data.displayName);
    localStorage.setItem('LyricsUserId', data.userId);

    this.router.navigateByUrl('/home');
  }

  getAccessToken() {
    return localStorage.getItem('LyricsToken');
  }

  getDisplayName() {
    return localStorage.getItem('LyricsDisplayName');
  }

  async isAuthenticated() {
    return lastValueFrom(this.http.get<boolean>(this.baseUrl + 'api/auth/'))
      .then((response: boolean) => {
        this.isAuth.next(response);
        return response;
      })
      .catch((err) => {
        this.isAuth.next(false);
        return false;
      });
  }
}
