using System;
using Xunit;
using UserTaskRESTService.Controllers;
using UserTaskRESTService.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UserTask_Tests
{
    public class TestTasksController
    {
        TasksController controller;

        //Create List of fake tasks for testing purpose
        private void setTestTasks()
        {
            TasksCRUD.getInstance().AddTask(new Tasks { id = 1, title = "Contact Plumber", description = "Contact plumber to arrange removing my old shower control", created = DateTime.Now, isCompleted = true });
            TasksCRUD.getInstance().AddTask(new Tasks { id = 2, title = "Take the dimensions", description = "Take the bathtub dimensions", created = DateTime.Now, isCompleted = false });
            TasksCRUD.getInstance().AddTask(new Tasks { id = 3, title = "Choose the tiles colour", description = "Finalise the colour for bathroom tiles", created = DateTime.Now, isCompleted = false });
            TasksCRUD.getInstance().AddTask(new Tasks { id = 4, title = "Take the dimensions", description = "Take the bathtub dimensions", created = DateTime.Now, isCompleted = false });
        }

        public TestTasksController()
        {
            controller = new TasksController();
        }

        [Fact]
        public void GetAllTasks_WhenCalled_ReturnsAllTasks()
        {
            setTestTasks();
            var testTasks = TasksCRUD.getInstance().getAllTasks();

            var result = controller.GetAllTasks();

            Assert.Equal(testTasks.Count, result.Count);
        }

        [Fact]
        public void GetTaskByID_ExistingIDPassed_ReturnsRightTask()
        {
            setTestTasks();
            var testTasks = TasksCRUD.getInstance().getTaskById(2);

            var okResponse = controller.GetTaskById(2) as OkObjectResult;

            var result = okResponse.Value as Tasks;
            //Assert.IsType<OkObjectResult>(result);
            Assert.Equal(testTasks.title, result.title);
        }

        [Fact]
        public void GetTaskByID_UnknownIDPassed_ReturnsNotFoundResult()
        {
            setTestTasks();
            var result = controller.GetTaskById(6);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PostNewTask_ObjectPassedWithMissingValue_ReturnsBadRequest()
        {
            setTestTasks();
            var newTask = new Tasks()
            {
                id = 5,
                description = "This",
            };
            controller.ModelState.AddModelError("title", "Required");
            var result = controller.PostNewTask(newTask);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PostNewTask_ValidObjectPassed_ReturnedResponseHasCreatedTask()
        {
            //Arrange
            setTestTasks();
            var newTask = new Tasks()
            {
                id = 5,
                title = "Tiles colour",
                description = "Finalise the tiles colour of the bathroom",
            };

            //Act
            var createdResponse = controller.PostNewTask(newTask) as CreatedAtActionResult;
            var result = createdResponse.Value as PostTaskResponse;

            //Assert
            Assert.IsType<PostTaskResponse>(result);
            Assert.Equal("Tiles colour", result.details.title);
        }

        [Fact]
        public void Update_NotExistingIDPassed_ReturnsNotFoundResponse()
        {
            setTestTasks();
            var updatedTask = new Tasks()
            {
                id = 101,
                title = "Tiles colour",
                description = "Finalise the tiles colour of the bathroom",
            };

            var result = controller.Update(5, updatedTask);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Update_ExistingIDPassed_Returns()
        {
            setTestTasks();
            var updatedTask = new Tasks()
            {
                id = 4,
                title = "Tiles colour",
                description = "Finalise the tiles colour of the bathroom",
            };

            var okResponse = controller.Update(5, updatedTask) as OkObjectResult;
            var result = okResponse.Value as Tasks;

            //Assert
            Assert.IsType<Tasks>(result);
            Assert.Equal("Tiles colour", result.title);
        }

        [Fact]
        public void Delete_NotExistingIDPassed_ReturnsNotFoundResponse()
        {
            setTestTasks();
            var result = controller.Delete(6);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ExistingIDPassed_ReturnsOkResult()
        {
            setTestTasks();
            var result = controller.Delete(4);
            Assert.IsType<OkResult>(result);
        }
    }
}
