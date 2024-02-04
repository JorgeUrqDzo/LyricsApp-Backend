import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { SecurityService } from './security.service';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  console.log('httpInterceptor :>> ', req);
  let token = localStorage.getItem("LyricsToken");
  if (token) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }
  return next(req);
};


@Injectable()
export class JwtInterceptor implements HttpInterceptor
{
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>
  {
    const _securityService: SecurityService = inject(SecurityService);
    let token = _securityService.getAccessToken();

    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }
    return next.handle(request);
  }
 }
