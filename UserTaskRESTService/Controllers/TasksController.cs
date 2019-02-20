/*
 * TasksController class has defined all the CRUD operations for Tasks entity 
*/

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using UserTaskRESTService.Models;

namespace UserTaskRESTService.Controllers
{
    [Route("api/user/1234/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        
        //Get api/Tasks
        public List<Tasks> GetAllTasks()
        {
            List<Tasks> taskList = TasksCRUD.getInstance().getAllTasks();
            return taskList;
        }

        // POST api/Tasks
        [HttpPost]
        public ActionResult PostNewTask([FromBody]Tasks request)
        {
            //Checking if any required fields are missing
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PostTaskResponse response = new PostTaskResponse();
            response = TasksCRUD.getInstance().AddTask(request);
            if(response is null)
            {
                return  BadRequest( new {
                    status = HttpStatusCode.BadRequest,
                    error = (string.Format("Task with id {0} is already found", request.id)),
                });
            }
            return CreatedAtAction("GetTaskById", new {id = response.details.id }, response);
        }

        // GET api/Tasks/5
        [HttpGet("{id}")]
        public ActionResult GetTaskById(int id)
        {
            Tasks task = TasksCRUD.getInstance().getTaskById(id);
            if(task is null)
            {
                return NotFound(new {
                    status = HttpStatusCode.NotFound,
                    error  = string.Format("No task found with ID = {0}", id)
                });
            }
            else
            {
                return Ok(task);
            }
        }

        // PUT api/Tasks/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Tasks request)
        {
            Tasks updatedTask = TasksCRUD.getInstance().UpdateTask(request, id);
            if (updatedTask is null)
            {
                return NotFound(new {
                    status = HttpStatusCode.NotFound,
                    error = string.Format("No task found with ID = {0}", id)
                });
            }
            else
            {
                return Ok(new {
                    message = "Successfully updated",
                    details = updatedTask
                });
            }
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Boolean status = TasksCRUD.getInstance().DeleteTask(id);
            if(status is true)
            {
                return Ok(new {
                    message = "Successfully deleted"
                });
            }
            else
            {
                return NotFound(new {
                    status = HttpStatusCode.NotFound,
                    error = string.Format("No task found with ID = {0}", id)
                });
            }
        }
    }
}
