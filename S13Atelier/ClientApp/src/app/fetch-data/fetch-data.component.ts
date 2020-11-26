import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public forecasts: S13[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<S13[]>(baseUrl + 'S13').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface S13 {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
