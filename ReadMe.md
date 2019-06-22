#### 06 - 22 - 19

I added a c# webapi that will talk to a SQL datatable called messages. 

Then I created extension directory and added teh configurecors method.

Then I added these methods to the startup.cs file ConfigureServices.

Next I created the LoggerService and Conract Projects. I connected Contracts > LoggerService > ElenorServer through refs.

I connected the LoggerService to the main project with the nlog.config file.

I created the ConfigureLoggerServices ExtensionMethod and added it to Startup.cs


#### Extension Methods

This file holds the configuration methods for the different middleware components the app will hold. 

| Method | Line | Description |
| -| -| - |
| ConfigureCors() | 19 | This method sets the header parameters that need to be met to access the database. I have configured this method to only allow requests from localhost:8080, and limited the request methods. |
| ConfigureIISIntegration() | 31 | Something to do with internet explorer? Not sure. |
| ConfigureLoggerService() | 39 | Adds the interface for the logger and the LoggerManager file to the startup ConfigureServices(). |

#### Contracts
Contracts holds Interfaces.
Interfaces are just the names of functions or variables used elsewhere.

Need to add more here.

| Interface | Purpose |
| - | - |
| ILoggerManager | Holds the method names for the logger |

#### LoggerService

This file holds the external reference to NLog - the third party logging library I am using.

The class extends the ILoggerManager interface. The constructor holds the logger named after the class using it with :

```LogManager.GetCurentClassLogger();```

The LoggerManager project holds one file that passes NLog messages around.

Once the LoggerService project has been created then we connect it to the main project in the nlog.config file.

Next I added the ConfigureLoggerService() method to the ServiceExtensions file.