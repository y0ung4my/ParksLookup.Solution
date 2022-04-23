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

## Known Bugs

* 

## License

MIT License

Copyright (c) 2022 Amy Young

Questions or comments: youngamy1223@gmail.com