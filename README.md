The Casting Place
===================

The Casting Place is a web application designed for **actors** and **casting agents**. The application allows actors to apply for castings which casting agents submitted. As an actor you can add movies and theatre plays that you acted in. You can see the database of movies and plays that the actors create as they update their profiles. All users can see which actors applied for a casting. There is an admin that approves every added casting, movie, play or role.

Features
--------

-   **Profile Creation**: Create and add info for yourself if you are an actor or a casting agent
-   **Adding New Casting**: Casting agents can create new castings for the actors.
-   **Applying for Casting**: Actors can apply to castings that look suitable for them.
-   **Improving Portfolio**: Actors can add roles in movies or plays to improve their portfolio and be more recognizable.
-   **Admin Panel**: Admins can approve and delete various entities, such as roles, movies, plays, and users.
  
Tech Stack
----------

-   **Frontend**: ASP.NET Core MVC, Razor Views with Bootstrap, CSS, JS
-   **Backend**: ASP.NET Core, Entity Framework Core
-   **Database**: Microsoft SQL Server
-   **Authentication**: ASP.NET Core Identity

Requirements
------------

-   .NET 6 or later
-   Microsoft SQL Server
-   Visual Studio or Visual Studio Code (with C# extension)

Installation
------------

Clone the repository, restore project dependencies, update your connection string in `appsetings.json` and apply migrations.

If you want to test the application as Admin, the username and password are in `appsetings.json`.

Role Management
---------------

This application uses role-based access control for security:

-   **Admin Role**: Users with the admin role can manage and approve actors, movies, plays, users and more.
-   **User Role**: Regular users are both actors and casting agents.

Project Architecture
---------------

The application is divided into several projects:
-    **ActorsCastings.Data**: The repository dbContext and all operations on the database.
-    **ActorsCastings.Data.Models**: The data models of the application.
-    **ActorsCastings.Services.Data**: All the services that hold the business logic and use the repositories.
-    **ActorsCastings.Web**: The Web part of the application - Controllers, Views, Areas, CSS, JS, Images etc.
-    **ActorsCastings.Web.Infrastructure**: Additional infrastructure that the Web project uses like extension methods and HTML helpers.
-    **ActorsCastings.Web.ViewModels**: The models that pass information from the Database to the Views.
-    **ActorsCastings.Common**: Constant messages, Exception messages etc.

License
-------

This project is licensed under the MIT License - see the LICENSE file for details.
