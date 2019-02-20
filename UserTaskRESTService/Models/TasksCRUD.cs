using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserTaskRESTService.Models
{
    public class TasksCRUD
    {
        List<Tasks> taskList;

        static TasksCRUD crud = null;
        private TasksCRUD()
        {
            taskList = new List<Tasks>();
        }
        public static TasksCRUD getInstance()
        {
            if (crud == null)
            {
                crud = new TasksCRUD();
                return crud;
            }
            else
            {
                return crud;
            }
        }

        //Method to add new task
        public PostTaskResponse AddTask(Tasks task)
        {
        
            task.created = DateTime.Now;
            task.status = "todo";
            task.isCompleted = false;
            taskList.Add(task);

            //Creating a response to send to client
            PostTaskResponse response = new PostTaskResponse();
            NewTask newTask = new NewTask();
            response.message = "Successfully created";
            newTask.id = task.id;
            newTask.title = task.title;
            newTask.description = task.description;
            newTask.status = task.status;
            newTask.created = task.created;
            newTask.due = task.due;
            response.details = newTask;

            return response;
        }

        //Method to get the list of all the user tasks
        public List<Tasks> getAllTasks()
        {
            return taskList;
        }


        //Method to get the specific Task details
        public Tasks getTaskById(int id)
        {
            for(int i = 0; i < taskList.Count; i++)
            {
                Tasks task = taskList.ElementAt(i);
                if (task.id.Equals(id))
                {
                    return taskList[i];
                }
            }
            return null;
        }

        //Method to update the Task record
        public Tasks UpdateTask(Tasks updatedTask , int id)
        {
            for(int i = 0; i < taskList.Count; i++)
            {
                Tasks task = taskList.ElementAt(i);
                if (task.id.Equals(id))
                {
                    taskList[i] = updatedTask;
                    return taskList[i];
                }
            }

            return null ;
        }

        //Method to delete a task
        public Boolean DeleteTask(int id)
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                Tasks task = taskList.ElementAt(i);
                if (task.id.Equals(id))
                {
                    taskList.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

    }
}
