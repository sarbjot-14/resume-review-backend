# Resume Review (Backend)

Web app to allow users to upload resumes and get feedback in order to make improvements to their resume. This repository contains the backend API built with .NET 7. The frontend for this project can be found here: https://github.com/sarbjot-14/resume-review-frontend


## Tech Stack
* **.Net 7** 
* **Postman** 
* **SQLite** 
* **Entity Framework** 

## Reflection

### Learning Outcomes
1. Clean Architecture which defines how dependancies and seperation of concerns should dictate organization and flow of code. 
2. Entity Framework to create database and do migrations.
3. Implementing CRUD with .Net controllers with CQRS pattern. Implemented CQRS pattern with MediatR Nuget package.
4. Converted data to domain objects using DTO's and Automapper
5. Created custom Error class and integrating error handling in middleware to send back custom error responses
6. Used Asp.Net Core Identity to manage authentication. 
7. Created data validation using FluentValidation nuget package
8. Generate Jason Web Token (JWT) with System.IdentityModel.Tokens. Jwt nuget package.
9. 


## How to run

Change dirctories to Api and run `dotnet run`
