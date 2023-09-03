import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Events } from 'src/models/Events';
import { JoinUserEvent } from 'src/models/JoinUserEvent';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  eventsJson: Events[];

  constructor(
    private userService: UserService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.userService
      .getEvents(this.route.snapshot.routeConfig?.path || '')
      .subscribe((eventsJson: Events[]) => {
        this.eventsJson = eventsJson;
      });
  }

  joinToEvent(eventId: number): void {
    this.userService
      .joinEvent(this.route.snapshot.routeConfig?.path || '', eventId)
      .subscribe((joinEvent: JoinUserEvent) => {});
  }
}
