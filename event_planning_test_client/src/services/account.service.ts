import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserAccount } from 'src/models/UserAccount';
import { VerifyUserEmail } from 'src/models/VerifyUserEmail';
import { HttpService } from './http.service';
import { UserToken } from 'src/models/UserToken';
import { LocalStorageService } from './localStorage.service';
import { LocalStorage } from 'src/models/LocalStorage';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(
    private httpService: HttpService,
    private localStorage: LocalStorageService
  ) {}

  registerUser(path: string, userData: UserAccount): Observable<UserAccount> {
    return this.httpService.post(path, userData);
  }

  verifyEmail(
    path: string,
    token: VerifyUserEmail
  ): Observable<VerifyUserEmail> {
    return this.httpService.post(path, token);
  }

  getUserToken(path: string, userData: UserAccount): Observable<UserToken> {
    return this.httpService.post(path, userData, false);
  }

  isUserAdmin(): boolean {
    const accessToken = this.localStorage.getToken(LocalStorage.AccessToken);
    const jwtData = accessToken.accessToken.split('.')[1];
    const decodedJwtData = JSON.parse(window.atob(jwtData));

    return decodedJwtData.role === 'Admin';
  }

  isUserAuth(): boolean {
    return this.localStorage.isKeyExists(LocalStorage.AccessToken);
  }
}
