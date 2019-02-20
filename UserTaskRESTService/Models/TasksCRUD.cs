/*
 * All the CRUD opeartions to be performed on Tasks resource have been implemented in this class. 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace UserTaskRESTService.Models
{
    public class TasksCRUD
    {

        static TasksCRUD crud = null;

        private TasksCRUD()
        {
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
            foreach(Tasks t in LoadData.tasksList)
            {
                if (! t.id.Equals(task.id))
                {
                    //Setup some default values onn creation of a new task
                    task.created = DateTime.Now;
                    task.isCompleted = false;
                    LoadData.tasksList.Add(task);

                    //Creating a response to send to client
                    PostTaskResponse response = new PostTaskResponse();
                    NewTask newTask = new NewTask();
                    response.status = 200;
                    response.message = "Successfully created";
                    newTask.id = task.id;
                    newTask.title = task.title;
                    newTask.description = task.description;
                    newTask.created = task.created;
                    newTask.due = task.due;
                    response.details = newTask;

                    return response;
                }
            }
            return null;
        }

        //Method to get the list of all the user tasks
        public List<Tasks> getAllTasks()
        {
            return LoadData.tasksList;
        }


        //Method to get the specific Task details
        public Tasks getTaskById(int id)
        {
            List<Tasks> tasksList = LoadData.tasksList;
            for(int i = 0; i < tasksList.Count; i++)
            {
                Tasks task = tasksList.ElementAt(i);
                if (task.id.Equals(id))
                {
                    return tasksList[i];
                }
            }
            return null;
        }

        //Method to update the Task record
        public Tasks UpdateTask(Tasks updatedTask , int id)
        {
            List<Tasks> tasksList = LoadData.tasksList;
            for (int i = 0; i < tasksList.Count; i++)
            {
                Tasks task = tasksList.ElementAt(i);
                if (task.id.Equals(id))
                {
                    tasksList[i] = updatedTask;
                    return tasksList[i];
                }
            }

            return null ;
        }

        //Method to delete a task
        public Boolean DeleteTask(int id)
        {
            List<Tasks> tasksList = LoadData.tasksList;
            for (int i = 0; i < tasksList.Count; i++)
            {
                Tasks task = tasksList.ElementAt(i);
                if (task.id.Equals(id))
                {
                    tasksList.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

    }
}
