import { Injectable } from '@angular/core';
import { Observable, catchError, tap, throwError } from 'rxjs';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  host = 'http://localhost:5080/';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private httpClient: HttpClient) {}

  get<T>(path: string, isUserEvent: boolean = true): Observable<T> {
    return this.httpClient.get<T>(this.host + path).pipe(
      tap(() => {
        if (isUserEvent) {
          console.log('Успешно');
        }
      }),
      catchError((error) => this.handleServerError(error))
    );
  }

  post<T>(
    path: string,
    data?: T,
    isUserEvent: boolean = true
  ): Observable<any> {
    return this.httpClient
      .post<T>(this.host + path, data, this.httpOptions)
      .pipe(
        tap(() => {
          if (isUserEvent) {
            console.log('Успешно');
          }
        }),
        catchError((error) => this.handleServerError(error))
      );
  }

  private handleServerError(error: HttpErrorResponse) {
    return throwError(() => error);
  }
}
