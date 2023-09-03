import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  constructor(private httpService: HttpService) {}

  createEvent(path: string, eventData: string): Observable<string> {
    return this.httpService.post(path, eventData);
  }
}
