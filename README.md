# Vestas Test Challenge

## Overview
This project is a test bench application designed to simulate and evaluate test sequences. It is built using Blazor, SignalR, and Blazorise Charts, among others, to provide real-time updates and graphical representation of test results.

The application allows users to define test sequences, execute them, and visualize the results through tables and line charts. The architecture follows a modular approach with separate components for the simulator, database access and UI.

## Running the Project

### Prerequisites
- **.NET 9 SDK**

### Steps to Run
1. **Clone the repository:**
   ```sh
   git clone https://github.com/Guilherme-Nuno/VestasTestChallenge.git
   cd VestasTestChallenge
   ```
2. **Restore dependencies:**
   ```sh
   dotnet restore
   ```
3. **Build the project:**
   ```sh
   dotnet build
   ```
4. **Run the application:**
   ```sh
   dotnet run --project VTC.BlazorUI
   ```
5. **Open the browser**
   Navigate to
   ```sh
   http://localhost:5291
   ```

## Limitations & Assumptions
- **Database Integration:** The system uses an SQLite database to store persistent data. A SQLite file is provided with some data already created.
- **Test Data Simulation:** The system does not interact with real hardware; all test sequences are virtual and the results are randomized.
- **Security & Authentication:** No authentication is provided.

## Technologies Used
- **Blazor Server** (UI framework)
- **SignalR** (Real-time communication)
- **Blazorise Charts** (Graph rendering)
- **SQLite** (Database integration)
- **.NET 9** (Core framework)
