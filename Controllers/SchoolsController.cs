using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace thepathbackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolsController : Controller
    {
        [HttpGet]
        [Route("AllSchools")]
        public IActionResult Get()
        {
            var schools = new List<object>
            {
                new { Name = "World", Address = "123 Gold Way Stockton, CA" },
                new { Name = "Hello", Address = "123 Plan Way Stockton, CA" }
            };
            return Json(schools);
        }
    }
}