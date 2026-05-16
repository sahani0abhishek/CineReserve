import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MovieService } from './movie.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  api = 'http://localhost:5057/api/Auth';

  isLoggedIn = false;
  showRegister = false;
  isAdmin = false;

  loginData = {
    email: '',
    password: ''
  };

  registerData = {
    fullName: '',
    email: '',
    passwordHash: ''
  };

  movies = [
    {
      id: 1,
      title: 'Avengers Endgame',
      description: 'Marvel Sci-Fi Action',
      duration: '3h 2m',
      image: 'https://m.media-amazon.com/images/I/81ExhpBEbHL.jpg',
      showtimeId: 101,
      showtimes: ['10:00 AM', '2:00 PM', '6:00 PM']
    },
    {
      id: 2,
      title: 'Interstellar',
      description: 'Space Adventure',
      duration: '2h 49m',
      image: 'https://m.media-amazon.com/images/I/91kFYg4fX3L.jpg',
      showtimeId: 102,
      showtimes: ['11:00 AM', '3:30 PM', '9:00 PM']
    },
    {
      id: 3,
      title: 'Joker',
      description: 'Psychological Thriller',
      duration: '2h 2m',
      image: 'https://m.media-amazon.com/images/I/71E7xF4v5jL.jpg',
      showtimeId: 103,
      showtimes: ['12:00 PM', '4:00 PM', '8:30 PM']
    }
  ];

  seats: any[] = [];
  selectedMovie: any = null;
  selectedSeats: any[] = [];
  soldSeatIds: number[] = [];

  constructor(
    private http: HttpClient,
    private movieService: MovieService
  ) {
    this.generateSeats();

    this.isLoggedIn = !!localStorage.getItem('token');
    this.isAdmin = localStorage.getItem('role') === 'Admin';
  }

  register() {
    this.http.post(this.api + '/register', this.registerData).subscribe({
      next: () => {
        alert('Registered Successfully');
        this.showRegister = false;
      },
      error: (err) => {
        alert(err.error);
      }
    });
  }

  login() {
    this.http.post<any>(this.api + '/login', this.loginData).subscribe({
      next: (res) => {
        localStorage.setItem('token', res.token);
        localStorage.setItem('user', res.fullName);
        localStorage.setItem('role', res.role);

        this.isLoggedIn = true;
        this.isAdmin = res.role === 'Admin';

        if (this.isAdmin) {
          alert('Admin Login Successful');
        } else {
          alert('User Login Successful');
        }
      },
      error: (err) => {
        alert(err.error);
      }
    });
  }

  logout() {
    localStorage.clear();
    this.isLoggedIn = false;
    this.isAdmin = false;
    this.selectedMovie = null;
    this.selectedSeats = [];
  }

  generateSeats() {
    const rows = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'];
    let id = 1;
    this.seats = [];

    for (let row of rows) {
      for (let i = 1; i <= 10; i++) {
        this.seats.push({
          id: id++,
          rowNumber: row,
          seatNumber: i,
          seatType: row === 'I' || row === 'J' ? 'VIP' : 'Standard'
        });
      }
    }
  }

  selectMovie(movie: any) {
    this.selectedMovie = movie;
    this.selectedSeats = [];
    this.soldSeatIds = [];
  }

  isSelected(seat: any) {
    return this.selectedSeats.some(x => x.id === seat.id);
  }

  isSold(seat: any) {
    return this.soldSeatIds.includes(seat.id);
  }

  toggleSeat(seat: any) {
    if (!this.isLoggedIn) {
      alert('Login first');
      return;
    }

    if (!this.selectedMovie) {
      alert('Select movie first');
      return;
    }

    if (this.isSold(seat)) return;

    if (this.isSelected(seat)) {
      this.selectedSeats = this.selectedSeats.filter(x => x.id !== seat.id);
    } else {
      this.selectedSeats.push(seat);
    }
  }

  getTotal() {
    return this.selectedSeats.reduce((sum, seat) => {
      return sum + (seat.seatType === 'VIP' ? 200 : 150);
    }, 0);
  }

  bookSeats() {
    if (!this.isLoggedIn) {
      alert('Login first');
      return;
    }

    if (this.isAdmin) {
      alert('Admin cannot book tickets');
      return;
    }

    if (!this.selectedMovie) {
      alert('Select movie first');
      return;
    }

    if (this.selectedSeats.length === 0) {
      alert('Select seats first');
      return;
    }

    this.selectedSeats.forEach(seat => {
      const booking = {
        userId: 1,
        showtimeId: this.selectedMovie.showtimeId,
        seatId: seat.id,
        rowNumber: seat.rowNumber,
        seatNumber: seat.seatNumber,
        price: seat.seatType === 'VIP' ? 200 : 150
      };

      this.movieService.bookSeat(booking).subscribe({
        next: () => {
          this.soldSeatIds.push(seat.id);
        },
        error: (err) => {
          alert(err.error || 'Seat Already Reserved');
        }
      });
    });

    alert('Booking Successful');
    this.selectedSeats = [];
  }

  addMovie() {
    alert('Admin: Add Movie Feature');
  }

  addShowtime() {
    alert('Admin: Add Showtime Feature');
  }

  viewBookings() {
    alert('Admin: View Bookings Feature');
  }
}
