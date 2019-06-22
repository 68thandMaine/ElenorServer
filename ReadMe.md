#### 06 - 22 - 19

I added a c# webapi that will talk to a SQL datatable called messages. 

Then I created extension directory and added teh configurecors method.

Then I added these methods to the startup.cs file ConfigureServices.

Next I created the LoggerService and Conract Projects. I connected Contracts > LoggerService > ElenorServer through refs.

#### Extension Methods

This file holds the configuration methods for the different middleware components the app will hold. 

| Method | Line | Description |
| -| -| - |
| ConfigureCors() | 19 | This method sets the header parameters that need to be met to access the database. I have configured this method to only allow requests from localhost:8080, and limited the request methods. |
| ConfigureIISIntegration() | 39 | Something to do with internet explorer? Not sure. |

#### Contracts
Contracts holds Interfaces.
Interfaces are just the names of functions or variables used elsewhere.

Need to add more here.

| Interface | Purpose |
| - | - |
| ILoggerManager | Holds the method names for the logger |

#### LoggerService