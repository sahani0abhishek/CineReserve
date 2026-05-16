# 🎬 CineReserve – Real-Time Movie Ticket Booking Platform

CineReserve is a full-stack real-time movie ticket booking platform built using **Angular**, **ASP.NET Core Web API**, and **MySQL**. It allows users to browse movies, select seats interactively, book tickets securely, and provides an admin dashboard for theatre management.

---

## 🚀 Features

### 👤 User Authentication
- User Registration
- User Login
- JWT-based Authentication
- Secure Password Hashing with BCrypt
- Logout functionality

---

### 🎥 Movie Browsing
Users can:
- View available movies
- See movie posters
- Read descriptions
- Check movie duration
- View multiple showtimes

Example:
- Avengers Endgame
- Duration: 3h 2m
- Showtimes:
  - 10:00 AM
  - 2:00 PM
  - 6:00 PM

---

### 💺 Interactive Seat Booking
Cinema hall layout:
- 10 × 10 seat matrix
- Rows: A → J
- Columns: 1 → 10

Seat states:
- 🟢 Available
- 🔵 Selected
- 🟡 VIP
- ⚫ Sold

Features:
- Interactive seat selection
- Dynamic pricing
- Real-time seat state updates

---

### 💳 Dynamic Checkout
Checkout panel displays:
- Selected movie
- Selected seats count
- Total ticket price

Pricing:
- Standard Seat: ₹150
- VIP Seat: ₹200

---

### 🛡️ Double Booking Prevention
Backend validates seat availability before booking.

Logic:
- Checks if seat already booked for same showtime
- Returns:
```text
Seat Already Reserved