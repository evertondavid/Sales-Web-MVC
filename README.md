# ASP.NET Core MVC Web Application

## Project Overview
This project is a web application developed using ASP.NET Core MVC, Entity Framework, and Bootstrap. It aims to provide a comprehensive understanding of building web applications with ASP.NET Core MVC, utilizing modern development practices and tools. The application includes complete CRUD functionality, a relational database integration with MySQL, and a responsive design powered by Bootstrap 5. Additionally, the project incorporates HTML5 and CSS3 for front-end development.

## Key Features
### Framework and Technologies
- **ASP.NET Core MVC (version 7.0)**: Used for building the web application with a clear separation of concerns through the Model-View-Controller architecture.
- **Entity Framework Core**: Implemented as the Object-Relational Mapper (ORM) for database operations, facilitating Code-First workflow and migrations.
- **Bootstrap 5**: Ensures responsive and modern UI design.
- **MySQL (version 5)**: Utilized as the database management system.
- **HTML5 and CSS3**: Employed for creating the structure and styling of the web pages.

### Project Structure
- **Controllers**: Handle user input and interactions.
- **Models**: Define the data structure and business logic.
- **Views**: Present data to the user and capture user input.
- **ViewModels**: Used for passing data between controllers and views.

### Database and Migrations
- Configured MySQL as the database provider.
- Implemented initial and subsequent migrations using EF Core for database schema updates.

### CRUD Operations
- Comprehensive Create, Read, Update, and Delete operations for entities such as Departments and Sellers.
- Leveraged EF Core's LINQ queries for data manipulation.

### Dependency Injection
- Employed ASP.NET Core's built-in Dependency Injection (DI) framework for service registration and management.

### User Interface
- Developed using Razor Pages, HTML5, and CSS3 for a seamless and interactive user experience.
- Included features like responsive design, form validations, and dynamic data display.

### Error Handling and Validation
- Implemented robust error-handling mechanisms.
- Used data annotations for server-side validation and client-side validation scripts.

### Asynchronous Operations
- Utilized asynchronous programming (async/await) for database operations to enhance performance.

## Additional Details
- **Version Control**: The project is version-controlled using Git and hosted on GitHub.
- **Deployment**: Configured for HTTPS and can be debugged using IIS.

## How to Run the Project
1. **Clone the repository**:
   ```bash
   git clone https://github.com/evertondavid/Sales-Web-MVC.git
