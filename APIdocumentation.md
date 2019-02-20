# API Documentation
This Application has implemenetd a REST Services in C# and ASP.NET core which allows Logged-in User to do the following :

### Allowed HTTP Requests :
PUT     : To create a Task
POST    : Update a task
GET     : Get a task or list of Tasks
DELETE  : To delete a task

### Description Of Usual Server Responses:
-   200  `OK`  - the request was successful (some API calls may return 201 instead).
    
-   201  `Created`  - the request was successful and a resource was created.
    
-   400  `Bad Request`  - the request could not be understood or was missing required parameters
-   404  `Not Found`  - resource was not found

### Health Check Service
Call following API to check the status of the service

    https://localhost:XXXXX/health
### Home API

    https://localhost:XXXXX/api/Home

## Reference

## Task
**Task Attributes:**
- userId `(Number)` : User identifier  
- id  `(Number)`  : unique identifier
- title `(String)`  : Task Name
- description `(String)`  : Description of the Task
- status `(String)`  : Status of the Task : todo or completed or deleted. 
- isCompleted `(boolean)` : Task completed or not
- created `(DateTime)` : Date and time when task is created
- due `(DateTime)` : Due Date and time of task completion
- completedAt `(DateTime)` : Date and time when task is completed

### Task Collection
Retrieve List of tasks of specified User, passing user Id in URL
> GET  `https:..localhost:XXXXX/api/user/1234/Tasks`

### Create a Task

> POST `https://localhost:XXXXX/api/user/1234/Tasks`
> Parameters `null`
> Request Body

     `{
        	"id":1,	
        	"title":"Chhan",
        	"description": "Trying my best"
        }`
> Response `200`

     `{
        	message: "Successfully created"
        	details : {
	        	"id":1,	
	        	"title":"Chhan",
	        	"description": "Trying my best",
	        	"status": "todo",
		        "created": "2019-02-20T13:02:22.2740218+00:00",
		        "due": "0001-01-01T00:00:00"
        	}
        }`

> Response `400`

     `{
        message: " X attribute is requird"
      }`

### Update a Task

> POST `https://localhost:XXXXX/api/user/1234/Tasks/id`
> Parameters `id`
> Request Body

     `{
        	"id":1,	
        	"title":"Change it",
        	"description": "Update the task with id 1",
        	"isCompleted" : true
        }`
> Response `200`

     `{
        	message: "Successfully updated"
        	details : {
	        	"id":1,	
	        	"title":"Chnage it",
	        	"description": "Update the task with id 1",
	        	"status": "todo",
	        	"ïsCompleted" : true,
		        "created": "2019-02-20T13:02:22.2740218+00:00",
		        "due": "0001-01-01T00:00:00"
        	}
        }`

> Response `404`

     `{
	    "status": 404,
	    "errorMessage": "No task found with ID = 3"
      }`