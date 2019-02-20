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

            new Tasks { id = 1, title = "Contact Plumber", description = "Contact plumber to arrange removing my old shower control", created = DateTime.Now, isCompleted = false },
            new Tasks { id = 2, title = "Take the dimensions", description = "Take the bathtub dimensions", created = DateTime.Now, isCompleted = false },
            new Tasks { id = 3, title = "Choose the tiles colour", description = "Finalise the colour for bathroom tiles", created = DateTime.Now, isCompleted = false }
    };
    }
}
