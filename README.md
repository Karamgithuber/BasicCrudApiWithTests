.NET Web API CRUD Project
Overview
This project is a .NET Web API application built with .NET 6+ and Entity Framework (Code First). It demonstrates basic CRUD (Create, Read, Update, Delete) operations for a User entity. The project also includes validation for the UserName field, ensuring it does not exceed 20 characters, using FluentValidation.

Additionally, the project includes unit tests written using xUnit to ensure the application logic is working correctly.

Features
CRUD Operations: Implements Create, Read, Update, and Delete operations for the User entity.

Validation: Adds validation on the POST API to ensure the UserName field is no longer than 20 characters using FluentValidation.

Unit Test: Unit tests are written with xUnit to verify the functionality of the application.

Requirements
.NET 6+ SDK: Ensure you have the latest .NET SDK installed. The project is built using .NET 6 or higher.

Entity Framework Core: The application uses Entity Framework Core with the Code First approach for data modeling.

FluentValidation: Validation of the UserName field using the FluentValidation library.

xUnit: Unit testing framework for .NET to test the API endpoints and business logic.

Setup
Prerequisites
Install .NET 6+ SDK from the official Microsoft .NET SDK page.

A code editor like Visual Studio Code or Visual Studio.

Install FluentValidation and xUnit packages (instructions included below).

Steps to Run the Project
Clone the repository:

bash
Copy
Edit
git clone https://github.com/Karamgithuber/BasicCrudApiWithTests.git
Navigate to the project directory:

bash
Copy
Edit
cd your-repo-name
Restore dependencies:

bash
Copy
Edit
dotnet restore
Apply migrations to set up the database:

bash
Copy
Edit
dotnet ef database update
Run the project:

bash
Copy
Edit
dotnet run
The Web API will be hosted at http://localhost:5000 by default.

API Endpoints
POST /api/users: Create a new user (UserName <= 20 characters).

GET /api/users: Get a list of all users.

GET /api/users/{id}: Get a specific user by ID.

PUT /api/users/{id}: Update an existing user.

DELETE /api/users/{id}: Delete a user.

Example User Model
csharp
Copy
Edit
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}
Validation on POST API
The POST API for creating a user includes validation to ensure that the UserName is no longer than 20 characters. This validation is implemented using FluentValidation.

csharp
Copy
Edit
public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.UserName).Length(0, 20).WithMessage("UserName must be less than or equal to 20 characters.");
    }
}
Unit Tests
The unit tests for the project are written using xUnit.

The tests verify the core logic of the API, including validation and data operations.
