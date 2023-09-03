import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';
import { Events } from 'src/models/Events';
import { JoinUserEvent } from 'src/models/JoinUserEvent';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpService: HttpService) {}

  getEvents(path: string): Observable<Events[]> {
    return this.httpService.get(path, false);
  }

  joinEvent(path: string, eventId: number): Observable<JoinUserEvent> {
    return this.httpService.post(path, eventId);
  }
}
