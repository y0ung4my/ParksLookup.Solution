# _National Parks API_

#### By _**Amy Young**_

#### _An API that lists state and national parks_

## Technologies Used

* _C#_
* _ASP.Net Core_
* _Entity Framework_
* _SQL_
* _.NET 5.0 CLI api template_


## Description

_This is a backend API application for storing information about state and national parks, including the park system (state or national), state, name, and a list (longtext string) of activities. It includes methods to GET (including queries), POST, PUT, and DELETE objects from the database._

**Database Structure**

_This database uses a many-to-many relationship structure_

## Setup/Installation Requirements

**To clone the repository**
* _open terminal_
* _enter the following into terminal: `git clone https://github.com/y0ung4my/Parks.Solution`_

**To run the application on your computer**
* _in the terminal application of your choice, navigate to the `Parks` directory then enter `dotnet restore` to install the necessary dependencies_
* _type `dotnet run` into the terminal_
* _Use Postman to Get, Post, Put, and Delete items in the database_

**Configure Database Connection**
* _create a file called `appsettings.json` in the root directory and enter the following:_

{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=parks_lookup;uid=root;pwd=[YOUR-PASSWORD-HERE];"
  }
}

**Update Database**
* _While in the production directory of the project, run `dotnet ef database update`_

**View Documentation**
* _After starting the server with `dotnet run` in the terminal, enter `http://localhost:5000/` into the browser and you will be redirected to `http://localhost:5000/index.html` - the swagger documentation_

**API Calls**
* GET `api/parks` - gets a list of all parks (both national and state)
* GET with query string example: `api/parks?parksystem=national` - gets a list of national parks
* POST `api/parks/` with json body - adds a park
* PUT `api/parks/{id}` with json body - edits an existing park
* DELETE `api/parks/{id}`
* more documentation below

**View More Documentation:**
* _After starting the server with `dotnet run` in the terminal, enter `http://localhost:5000/` into the browser and you will be redirected to `http://localhost:5000/index.html` - the swagger documentation_

## Known Bugs

* swagger documentation could be completed further
* activities can only be searched one at a time (not by multiple activities) because the    activities value is one string

## License

MIT License

Copyright (c) 2022 Amy Young

Questions or comments: youngamy1223@gmail.com