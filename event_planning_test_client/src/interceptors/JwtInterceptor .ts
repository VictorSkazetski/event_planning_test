import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalStorage } from 'src/models/LocalStorage';
import { AccountService } from 'src/services/account.service';
import { LocalStorageService } from 'src/services/localStorage.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(
    private account: AccountService,
    private localStorage: LocalStorageService
  ) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (this.account.isUserAuth()) {
      if (request.url.includes('admin')) {
        request = request.clone({
          setHeaders: {
            Authorization: `Bearer ${
              this.localStorage.getToken(LocalStorage.AccessToken).accessToken
            }`,
          },
        });
      }
    }

    return next.handle(request);
  }
}
