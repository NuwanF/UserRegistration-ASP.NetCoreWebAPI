# UserRegistration-ASP.NetCoreWebAPI
A sample user registration API with ASP .Net Core 6.0 and MySQL

## Setup
* Download the UserRegistration sollution which contains two projects
* Change database connection strings in UserRegistration -> appsettings.json file
* Run below script in Package Manager Console to generate database with data
```bash
"update-database"
```
* Run UserRegistration project and you will find a Swagger UI, where you will find the endpoints

## Implementation and Best Practices
* **Generic Repository Pattern** is used to minimize the repetition and have single base repository work for all type of data
* **Unit of Work** is used to maintain a single transaction that involves multiple CRUD operations
* **Code First** approach is used to generate database
* A **Three-tier Architecture** including Repository Layer, Business Logic Layer and Controller Layer is used to structure the project
* **Dependency Injection** is used to maintain loose coupling between each layer and inject low level classes in to high level classes
* **JWT Authentication**
* **Asynchronous database calls**
* **MySQL Database** is used to make it much easier when deploying the application other than Microsoft Servers 

## Reference
https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/
https://github.com/NuwanF/SampleDotNetCoreMVCWithEF
