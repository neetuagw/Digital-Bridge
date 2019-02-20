/*
 * HomeController class will call upon by default on running this service. 
*/

using System;
using Microsoft.AspNetCore.Mvc;

namespace UserTaskRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/Home
        [HttpGet]
        public String Get()
        {
            return "USER REST Service for DigitalBridge Bathroom Installation Planning" 
                + "\n" + "Call GET/POST/PUT/DELETE methods to api/user/1234/Tasks";
        }

    }
}
