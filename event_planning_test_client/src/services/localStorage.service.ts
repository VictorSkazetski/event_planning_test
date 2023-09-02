import { Injectable } from '@angular/core';
import { UserToken } from 'src/models/UserToken';

@Injectable({
  providedIn: 'root',
})
export class LocalStorageService {
  saveToken(key: string, value: UserToken) {
    localStorage.setItem(key, JSON.stringify(value));
  }

  getToken(key: string): UserToken {
    return JSON.parse(localStorage.getItem(key) || '') as UserToken;
  }

  removeToken(key: string) {
    localStorage.removeItem(key);
  }

  clearLocalStorage() {
    localStorage.clear();
  }

  isKeyExists(key: string): boolean {
    return localStorage.getItem(key) !== null;
  }
}
