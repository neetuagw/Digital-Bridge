/* This is the test class to test services defined in TasksController
 */

using System;
using Xunit;
using UserTaskRESTService.Controllers;
using UserTaskRESTService.Models;
using Microsoft.AspNetCore.Mvc;

namespace UserTask_Tests
{
    public class TestTasksController
    {
        TasksController controller;

        public TestTasksController()
        {
            controller = new TasksController();
        }

        [Fact]
        public void GetAllTasks_WhenCalled_ReturnsAllTasks()
        {
            //Arrange
            var testTasks = LoadData.tasksList;

            //Act
            var result = controller.GetAllTasks();

            //Assert
            Assert.Equal(testTasks.Count, result.Count);
        }

        [Fact]
        public void GetTaskByID_ExistingIDPassed_ReturnsRightTask()
        {
            //Arrange
            var testTasks = TasksCRUD.getInstance().getTaskById(1);

            //Act
            var okResponse = controller.GetTaskById(1) as OkObjectResult;
            var result = okResponse.Value as Tasks;

            //Assert
            Assert.IsType<OkObjectResult>(okResponse);
            Assert.Equal("Contact Plumber", result.title);
        }

        [Fact]
        public void GetTaskByID_UnknownIDPassed_ReturnsNotFoundResult()
        {
            //Act
            var result = controller.GetTaskById(6);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostNewTask_ObjectPassedWithMissingValue_ReturnsBadRequest()
        {
            //Arrange
            var newTask = new Tasks()
            {
                id = 5,
                description = "This",
            };
            controller.ModelState.AddModelError("title", "Required");

            //Act
            var result = controller.PostNewTask(newTask);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PostNewTask_ValidObjectPassed_ReturnedResponseHasCreatedTask()
        {
            //Arrange
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
            //Arrange
            var updatedTask = new Tasks()
            {
                id = 101,
                title = "Tiles colour",
                description = "Finalise the tiles colour of the bathroom",
            };

            //Act
            var result = controller.Update(101, updatedTask);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Update_ExistingIDPassed_Returns()
        {
            //Arrange
            var updatedTask = new Tasks()
            {
                id = 1,
                title = "Tiles colour",
                description = "Finalise the tiles colour of the bathroom",
            };

            //Act
            var result = controller.Update(1, updatedTask);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Delete_NotExistingIDPassed_ReturnsNotFoundResponse()
        {
            //Act
            var result = controller.Delete(6);
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Delete_ExistingIDPassed_ReturnsOkResult()
        {
            //Act
            var result = controller.Delete(3);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
