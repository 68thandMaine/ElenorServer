#### 06 - 22 - 19

I added a c# webapi that will talk to a SQL datatable called messages. 

Then I created extension methods and configured cors.

#### Extension Methods

This file holds the configuration methods for the different middleware components the app will hold. 

| Method | Line | Description |
| -| -| - |
| ConfigureCors() | 19 | This method sets the header parameters that need to be met to access the database. I have configured this method to only allow requests from localhost:8080, and limited the request methods. |
| ConfigureIISIntegration() | 39 | Something to do with internet explorer? Not sure. |