import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/services/http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'event_planning_test_client';

  constructor(private httpService: HttpService) {}

  ngOnInit(): void {
    this.httpService.get('WeatherForecast').subscribe((resp) => {
      console.log(resp);
    });
  }
}
