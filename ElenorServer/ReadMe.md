# Eleno-r Server

> ***Last Update: 07.31.2019***

## Table of Contents

|Chapter | Subject | Chapter | Subject |
|-|-|-|-|
| I | [Description](#description) | V | [Testing](#testing) |
| II | [Directory Diagram](#directory-diagram) | VI | [Database Structure](#database-structure) |
| III | [Projects](#projects) | VII | [Acknowledgments](#acknowledgements) |
| IV | [Installation and Usage](#installation-and-usage) | VIII | [Licensing Information](#licensing-information) |

___

## Description

Eleno-r Server is the backend for Eleno-r and Mission Control. It is a C# web api that uses the Entity ORM framework to manage data communication to a MySQL database.

As it stands, this project employs a repository design and unit-of-work pattern. This is arguably overkill for a simply CRUD application, as Entity Framework already provides a layer of abstraction between the **data logic and business logic**. For a simple project like this one, the only clear advantage that I see of employing this design pattern is that I can manipulate multiple entities and call save once. If there is an issue with any of the entities then none will be updated. This ensures that our databases are never out of synch.

I am developing this project with a TDD approach. Using MSTest I am providing unit tests. Please see the [Testing](#testing) chapter for more details.

___

## Directory Diagram

Below is the file structure for the Solution. Note that there are multiple projects within this solution. Detailed documentation on these projects can be found in the [Projects chapter](#projects).

<ul>
  <li>Root</li>
  <ul>
    <li>Contracts</li>
      <ul>
        <li>ILoggerManger.cs</li>
        <li>IMessageRepository.cs</li>
        <li>IRepositoryBase.cs</li>
        <li>IRepositoryWrapper.cs</li>
      </ul>
    <li>Documentation</li>
    <li>ElenorServer</li>
      <ul>
        <li>Controllers</li>
          <ul>
            <li>MessageController.cs</li>
          </ul>
        <li>Extensions</li>
          <ul>
            <li>ServiceExtensions.cs</li>
          </ul>
        <li>nlog.config</li>
        <li>Program.cs</li>
        <li>Startup.cs</li>
      </ul>
    <li>ElenorServer.Tests</li>
      <ul>
        <li>ControllerTests</li>
      </ul>
    <li>Entities</li>
      <ul>
        <li>Models</li>
        <li>RepositoryContext.cs</li>
      </ul>
    <li>LoggerService</li>
        <ul>
          <li>LoggerManager.cs</li>
        </ul>
    <li>Repository</li>
      <ul>
        <li>MessageRepository.cs</li>
        <li>RepositoryBase.cs</li>
        <li>RepositoryWrapper.cs</li>
      </ul>
  </ul>
</ul>

___

## Projects

The ElenorServer solution contains multiple projects to separate concerns.

### Contracts

The Contracts project contains interfaces that are used throughout the project. Interfaces act as the method signatures for our classes.

To learn more about the Contracts project [Click Me](./Documentation/Projects/Contracts.md)

### ElenorServer

The ElenorServer project is a C# web api that contains the controllers for the API and the launch settings.

To learn more about the ElenorServer project [Click Me](./Documentation/Projects/ElenorServer.md)

### ElenorServer.Tests

The ElenorServer.Tests project contains unit tests for the controllers.

To learn more about the ElenorServer.Tests project [Click Me](./Documentation/Projects/ElenorServerTests.md)

### Entities

The Entities project holds our entity classes and our Database connection.

To learn more about the Entities project [Click Me](./Documentation/Projects/Entities.md)

### LoggerService

The LoggerService project contains the logic the application uses for creating log messages.

To learn more about the LoggerService project [Click Me](./Documentation/Projects/LoggerService.md)

### Repository

The Repository project is the heart and soul of the repository design + unit of work pattern. The project contains a repository base that defines shared functionality, a file to encapsulate entity class repositories, and the entity class repository files.

To learn more about the Repository project [Click Me](./Documentation/Projects/Repository.md)

___

## Installation and Usage

The ElenorServer solution is still in development. To install this project on a local machine you will need to clone it down from the Github rep and then run ```dotnet restore``` to install the solution dependencies.

The project will have multiple branches. Master and Develop will be the most interesting branches to pull down. Master will contain code that has been fully tested and is ready for production. Develop will act as the merging branch for my feature branches. Each feature should be tested in isolation with unit tests, and then tested in the Develop branch again. If there are issues in the Develop branch after merging with a feature, then I will correct it here before merging develop into master.
___

## Testing

I am developing this solution with a TDD approach. Each Controller will have a test to ensure that the correct actions are taken. At this time I am looking into using Moq to Mock my DbContexts. It is proving especially difficult to test Entity and a repository design pattern due to inheritance and type conversions.

One advantage of using a repository pattern is that you really can separate your concerns by isolating code in different files. Whenever a file is needed, elsewhere in the project it is passed in as a property or it inherits from a base class. One issue that this has caused for me while writing tests is understanding what files I need to instantiate in the controller tests. For example: each controller receives the loggerservice and the repositorycontext when it is created. This allows the logger to create log files for the specific controller, and the gives the controller access to its DbSet. To test the controller we must create a new controller instance in the test, but you must pass in the appropriate parameters as well. Thus far I have had issues passing in the correct repositorycontext.

One solution to the prior issue is to use a mocking framework to mock my Db calls. I am using Moq to accomplish this functionality, and while this has solved my issues around instantiating new controllers, but creates an issue converting types. The current error I am recieving occurs when I try to program my mock DbSet to return the object I am testing. MSTest cannot covert a Moq to an EntityEntry.

___

## Database Structure  

<em>Under Construction</em>
___

## Acknowledgments

I created this solution with the help of:

Epicodus

Code Maze tutorial on consuming C# Web Apis with JavaScript SPA's https://code-maze.com/net-core-series/

The wonderful people of StackOverflow

The Microsoft Documentation.
___

## Licensing Information

MIT 2019
___
