# BIP-12 Task Management REST Service
**Digital Bridge Development Task**

This Application has implemenetd a REST Services in C# and ASP.NET core which allows Logged-in User to do the following :

 1. Create new task
 2. Get the List of tasks of specified User
 3. Mark task as completed or Modify the existing task 
 5. Delete the task

**Technology Used**
C# and ASP.Net Core

**Prerequisites**
Visual Studio 2017 Community, Professional or Enterprise Edition

**Software version**
- Visual Studio 2017 
- .NET Framework Core 2.2

**Libraries used in this Application**
- Microsoft.AspNetCore.App (2.2.0)
- Microsoft.AspNetCore.Diagnostics.HealthChecks (2.2.0)
- Microsoft.AspNetCore.Razor.Design (2.2.0)
- Microsoft.VisualStudio.Web.CodeGeneration.Design (2.2.0)


## Instructions to run this application

 -  Download and install Microsoft visual studio 2017 community, professional or enterprise edition
 - Clone this directory in your local system
 - To open this existing application in your Visual Studio, Select File > Open > Path to this directory. 
 - Once the solutions have been loaded completely in Visual Stuido, all you need is to run this service.  
 - In your Visual Studio menu bar, you can see a green arrow button "IIS Express". Here you can select a browser installed in your system and click it. It will start your web server and run this web service application on localhost.
 - By default, this service will run the "/api/home" API
 - Please follow the APIdocumentation.md file to call other URLs. 

## Test the REST Service

To test this service , run the test project "UserTask-tests". To run the tests, select the UserTask-Tests and in your Visual Stuido menu bar, Select Test > Run > All Tests.  
