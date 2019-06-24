# Eleno-r Server

## Table of Contents

|Chapter | Subject | Chapter | Subject |
|-|-|-|-|
| I | Task Step List | V | Testing the Server |
| II | Directory Diagram | VI | Database Structure |
| III | Projects | VII | Acknowledgments |
| IV | Installation and Usage | VIII | Licensing Information |

___

### Task Step List

- Created a SQL database with one table: Messages. (6/19)

- I created a C# Web API project called ***ElenorServer***. (6/19)

- I created a directory called **Extensions** within the ***ElenorServer*** project. (6/19)

- Within the **Extensions** directory I created a file called *ServiceExtensions*. This file will hold methods that will be used in the *Startup.cs* `ConfigureServices()` method. (6/19)

- I created the `ConfitureCors()` method in *ServiceExtensions* and added it to the `ConfigureServices()` method in *Startup.cs*. (6/19)

- I created two new projects: ***Contracts*** and ***LoggerService***. (6/19)
  
  - ***Contracts*** is referenced in ***LoggerService***. ***LoggerService*** is referenced in ***ElenorServer***.

- I added the Nuget package NLog to ***LoggerService***. (6/19)

- I created *nlog.config* in the ***ElenorServer*** project. This file contains XML that directs NLog where to store the .txt logfiles. (6/19)

- I created the `ConfigureLoggerServices()` extension method in *ServiceExtensions* and added it to *Startup.cs*. (6/19)

- I created two new projects: ***Entities*** and ***Repository***. (6/21)

- In the ***Entitites*** project I created a subdirectory called **Models** and the file *MessagesModel* that corresponds to the Messages datatable. (6/21)

- In the ***Entities*** project I created a file *RepositoryContext.cs* to communicate to the database. (6/21)

- I created the `ConfigureMySqlContext()` method in the **ServiceExtensions** file, and added it to the `ConfigureServices()` method in *Startup.cs*. (6/21)

I added CRUD funtionality method names to the Interface for the repositorybase. Then I created the Repository Project. (6/23)

After creating the RepositoryBase methods, I created a IMessagesRepository interface for the methods for messages. (6/23)

I created a Messages Controller and wrote a method for creating a Message. I will write a  create and get method before switching to tests. (6/23)

I created a repository wrapper. (6/23)

- I created the `ConfigureRepositoryWrapper()` method in *ServiceExtensions.cs*, and added it to the `ConfigureServices()` method in *Startup.cs*. (6/24)

- I wrote an HTTP GET request for all Messages in the *MessagesController.cs* file. (6/24)

- I tested the POST and GET method for creating a message and getting all messages in Postman. (6/24)

- I added the project ***ElenorServer.Tests*** and created a test for the *MessagesController.cs* file. (6/24)

- I created a `GetMessageById()` method. (6/24)

  - Created name in ***Contracts*** / *IMessagesRepository.cs*.
  - Created the method in ***Repository*** / *MessagesRepository.cs*.
___

### Extension Methods

This file holds the configuration methods for the different middleware components the app will hold. 

| Method | Line | Description |
| -| -| - |
| ConfigureCors() | 19 | This method sets the header parameters that need to be met to access the database. I have configured this method to only allow requests from localhost:8080, and limited the request methods. |
| ConfigureIISIntegration() | 31 | Something to do with internet explorer? Not sure. |
| ConfigureLoggerService() | 39 | Adds the interface for the logger and the LoggerManager file to the startup ConfigureServices(). |
| ConfigureMySqlContext() | 44 | Adds a DbContext using the mysqlconnection keyvalue pair in appsettings.jsonand the context file created in Entities |
| ConfigureRepositoryWrapper() | 50 |  |

#### Contracts
Contracts holds Interfaces.
Interfaces are just the names of functions or variables used elsewhere.

Need to add more here.

| Interface | Purpose |
| - | - |
| ILoggerManager | Holds the method names for the logger |
| IRepositoryWrapper | Holds the names for the Repositories and the Save method |

#### LoggerService

This file holds the external reference to NLog - the third party logging library I am using.

The class extends the ILoggerManager interface. The constructor holds the logger named after the class using it with :

```LogManager.GetCurentClassLogger();```

The LoggerManager project holds one file that passes NLog messages around.

Once the LoggerService project has been created then we connect it to the main project in the nlog.config file.

Next I added the ConfigureLoggerService() method to the ServiceExtensions file, added the LogManager Config to the Startup method.

Added Microsoft.EntityFrameworkCore to Entities project, and Pomelo.EntityFrameworkCore.MySql to main project

added mysqlconnection to appsettings.json in main

#### Entities

The Entities project holds the Models, Extended Models, our DataBase connection, and 

Entities
|__ExtendedModels
|__Etensions
|__Models
|__RepositoryContext.cs
|__IEntity.cs


##### Models

The Models subdirectory is created first. It holds classes that represent the SQL datatables. These models are clean, they only have properties that match the columns in the tables. 

##### RepositoryContext.cs

This file is middleware component for communication with the database. The DbSet properties contain the table data from the database.

#### Repository

The Repository project holds methods for interacting with the database. Each class has thier own set of methods, but all classes have access to the repository base class funtions.

The RepositoryBase file contains the basic CRUD methods that each model will inherit from. 

##### MessagesRepository

##### RepositoryBase

##### RepositoryWrapper