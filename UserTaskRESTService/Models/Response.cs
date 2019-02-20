using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UserTaskRESTService.Models
{
    public class PostTaskResponse
    {

        public String message { get; set; }

        public NewTask details { get; set; }

    }

    public class NewTask
    {
        public int id { get; set; }

        public String title { get; set; }

        public String description { get; set; }

        public String status { get; set; }

        public DateTime created { get; set; }

        public DateTime due { get; set; }
    }

    public class PutTaskResponse
    {
        public String message { get; set; }

        public Tasks details { get; set; }

    }
}
