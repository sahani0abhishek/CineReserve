import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  api = 'http://localhost:5057/api';

  constructor(private http: HttpClient) { }

  getMovies() {
    return this.http.get<any[]>(`${this.api}/Movies`);
  }

  getSeats() {
    return this.http.get<any[]>(`${this.api}/Seats/Hall-A`);
  }

  bookSeat(data: any) {
    return this.http.post(`${this.api}/Booking`, data);
  }
}
