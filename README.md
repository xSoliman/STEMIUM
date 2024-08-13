# STEMIUM - E-Learning Platform for STEM Students

STEMIUM is an e-learning platform designed to support STEM students by providing educational materials, feedback features, and user profiles. Built using ASP.NET MVC (.NET 7), the website accommodates different types of users including students, teachers, and parents. Additionally, administrators have full control over the website content and user feedback.

## Features

### Users
- **Student, Teacher, Parent:** 
  - Register and sign in.
  - View and explore educational materials.
  - Provide feedback on the materials.
  - Access and update profile information.
  - Change password.
  - Download materials in PDF format.
  - Materials displayed are specific to the user type.

### Admin
- **Admin Capabilities:**
  - Upload, edit, and delete educational materials.
  - Control visibility of user feedback on the homepage.
  - Manage admin accounts (create and delete).

## Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/STEMIUM.git
   ```
2. **Navigate to the project directory:**
   ```bash
   cd STEMIUM
   ```
3. **Restore the project dependencies:**
   ```bash
   dotnet restore
   ```
4. **Set up the database:**
   - Update the connection string in `appsettings.json` to point to your database.
   - Apply migrations to set up the database schema:
     ```bash
     dotnet ef database update
     ```

5. **Run the application:**
   ```bash
   dotnet run
   ```

### Usage

1. Open your browser and navigate to `https://localhost:5001` (or the URL where your application is hosted).
2. Register as a new user or log in with an existing account.
3. Explore materials, provide feedback, and manage your profile.
4. Admins can access the admin panel to manage content and feedback.

## Project Structure

- **Controllers:** Handle HTTP requests and responses.
- **Models:** Define the data structure and business logic.
- **Views:** Present the user interface.
- **wwwroot:** Static files (CSS, JS, images).
- **Data:** Database context and migrations.

## Contributing

Contributions are welcome! Please follow these steps to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add your feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a Pull Request.


---

Thank you for using STEMIUM, the e-learning platform for STEM students!
```

Make sure to replace placeholders like `https://github.com/yourusername/STEMIUM.git` and `yourname@example.com` with your actual GitHub repository link and contact email. Also, update any other necessary project-specific details as required.
