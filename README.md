The Casting Place
===================

The Casting Place is a web application designed to manage actors, movies, plays, and castings. The application allows users to apply for roles in movies or plays, and for admins to manage and approve applications, as well as edit and delete data related to actors, movies, and plays.

Features
--------

-   **Actors Management**: Manage actors, their profiles, and applications.
-   **Movies & Plays Management**: Create and edit movies and plays, including associated roles.
-   **Casting Process**: Apply actors to specific casting roles for movies and plays.
-   **Admin Panel**: Admin users can approve, edit, and delete various entities, such as actors, movies, plays, and users.
-   **Role-based Authorization**: Separate functionality for users and administrators with distinct permissions.

Tech Stack
----------

-   **Frontend**: ASP.NET Core MVC with Razor Views
-   **Backend**: ASP.NET Core, Entity Framework Core
-   **Database**: Microsoft SQL Server
-   **Authentication**: ASP.NET Core Identity
-   **Frontend Framework**: HTML, CSS (Bootstrap)

Requirements
------------

-   .NET 6 or later
-   Microsoft SQL Server
-   Visual Studio or Visual Studio Code (with C# extension)
-   Node.js (if you are building or running frontend assets)

Installation
------------

1.  **Clone the repository**:

    bash

    Copy code

    `git clone https://github.com/yourusername/actors-castings.git
    cd actors-castings`

2.  **Restore dependencies**: Run the following command to restore the project dependencies:

    bash

    Copy code

    `dotnet restore`

3.  **Set up the database**: The project uses Entity Framework Core for database interactions. Create the database and apply the migrations:

    bash

    Copy code

    `dotnet ef database update`

4.  **Configure application settings**: Update the `appsettings.json` file to include your database connection string and other necessary configurations.

5.  **Run the application**: After setting up the database and configurations, you can start the application by running:

    bash

    Copy code

    `dotnet run`

    Navigate to `https://localhost:5001` in your browser to access the app.

Role Management
---------------

This application uses role-based access control (RBAC) for security:

-   **Admin Role**: Users with the admin role can manage and approve actors, movies, plays, users, and more.
-   **User Role**: Regular users can apply for casting roles in movies or plays.

You can add users and assign them roles through the application's admin panel.

Admin Features
--------------

-   **Approve Content**: Admins can approve actors, movies, and plays for use in the system.
-   **Edit Content**: Admins can edit and delete movies, plays, castings, and users.
-   **Manage Users**: Admins can manage users, assign roles, and delete user accounts.

Folder Structure
----------------

/ActorsCastings
│
├── /ActorsCastings.Web
│   ├── /Controllers
│   │   ├── Admin
│   │   │   ├── ApprovalController.cs
│   │   │   ├── EditCastingController.cs
│   │   │   ├── EditMovieController.cs
│   │   │   └── EditUserController.cs
│   │   └── HomeController.cs
│   ├── /Views
│   │   ├── /Admin
│   │   │   ├── Approve.cshtml
│   │   │   └── Index.cshtml
│   ├── /Models
│   └── /Infrastructure
│       ├── /Extensions
│       └── /HtmlHelpers
│
├── /ActorsCastings.Data
│   ├── /Repository
│   │   └── BaseRepository.cs
│   └── /Models
│       └── ApplicationUser.cs
│
└── /ActorsCastings.Services
 └── /Interfaces
        └── IAdminService.cs 

### Controllers:

-   **Admin Controllers**: Manage the CRUD operations for actors, movies, plays, and users.
-   **ApprovalController**: Handles approval of items awaiting admin review.
-   **Edit Controllers**: Provide functionality for editing and deleting various data (casting, movie, play, user).

### Services:

-   **IAdminService**: Defines the business logic for handling administrative tasks like adding, approving, or deleting items.

### Repositories:

-   **BaseRepository**: A generic repository used to interact with the database for all entities in the system.

### HTML Helpers:

-   **HighlightMatch**: Highlights search query matches within text.

Running the Application Locally
-------------------------------

1.  Clone the repository and open the project in your preferred IDE (Visual Studio or Visual Studio Code).
2.  Run `dotnet restore` to restore dependencies.
3.  Run the application with `dotnet run` and navigate to `https://localhost:5001` in your browser.
4.  To seed the admin role, ensure your application is configured to add an admin user upon startup using the seed functionality.

Contributing
------------

1.  Fork the repository.
2.  Create a new branch (`git checkout -b feature-name`).
3.  Commit your changes (`git commit -am 'Add new feature'`).
4.  Push the branch (`git push origin feature-name`).
5.  Open a pull request and describe your changes.

License
-------

This project is licensed under the MIT License - see the LICENSE file for details.
