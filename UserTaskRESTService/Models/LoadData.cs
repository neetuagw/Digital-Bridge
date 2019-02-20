using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserTaskRESTService.Models
{
    public static class LoadData
    {
        public static List<Tasks> tasksList = new List<Tasks>()
        {

            new Tasks { id = 1, title = "Contact Plumber", description = "Contact plumber to arrange removing my old shower control", created = DateTime.Now, isCompleted = true }
    };
    }
}
