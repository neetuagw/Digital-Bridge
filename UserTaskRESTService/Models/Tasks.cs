/*
 * Task resource class with all fields 
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace UserTaskRESTService.Models
{
    public class Tasks
    {

        public int userID = 1234;

        [Required]
        public int id { get; set; }

        [Required]
        public String title { get; set; }

        public String description { get; set; }

        public DateTime created { get; set; }

        public Boolean isCompleted { get; set; }

        public DateTime due { get; set; }

        public DateTime completedAt { get; set; }
    }
}
