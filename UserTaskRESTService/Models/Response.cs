/*
 * This class will be used to generate responses as per the HTTP requests
 */

using System;

namespace UserTaskRESTService.Models
{
    public class PostTaskResponse
    {

        public int status { get; set; }
        public String message { get; set; }
        public NewTask details { get; set; }

    }

    public class NewTask
    {
        public int id { get; set; }

        public String title { get; set; }

        public String description { get; set; }

        public DateTime created { get; set; }

        public DateTime due { get; set; }
    }

    public class PutTaskResponse
    {
        public String message { get; set; }
        public Tasks details { get; set; }

    }
}
