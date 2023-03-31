using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using thepathbackend.Models;
using thepathbackend.Models.DTO;

namespace thepathbackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolsController : ControllerBase
    {
        private static List<SchoolsModel> _schools = new List<SchoolsModel>()
        {
            new SchoolsModel { Id = 0, Name = "Andre de Freitas Brazilian Jiu-Jitsu", Address = "654 Grider Way B, Stockton, CA 95210" },
            new SchoolsModel { Id = 1, Name = "Ares BJJ Stockton - Buffalo Black Brotherhood", Address = "7475 Murray Dr #6, Stockton, CA 95210" },
            new SchoolsModel { Id = 2, Name = "VALOR Training Center", Address = "9937 Lower Sacramento Rd, Stockton, CA 95210" },
            new SchoolsModel { Id = 3, Name = "Inside BJJ Academy", Address = "3422 W Hammer Ln suite g, Stockton, CA 95219" },
            new SchoolsModel { Id = 4, Name = "Stockton JiuJitsu Academy", Address = "2222 Grand Canal Blvd #8, Stockton, CA 95207" },
            new SchoolsModel { Id = 5, Name = "Stockton Dominate MMA", Address = "6360 Pacific Ave #1, Stockton, CA 95207" },
            new SchoolsModel { Id = 6, Name = "Nick Diaz Academy", Address = "3802 Wilcox Rd, Stockton, CA 95215" },
            new SchoolsModel { Id = 7, Name = "10th Planet Stockton", Address = "3422 W Hammer Ln suite g, Stockton, CA 95219" },
            new SchoolsModel { Id = 8, Name = "TEAM CAMA", Address = "8909 Thornton Rd #2, Stockton, CA 95209" },
            new SchoolsModel { Id = 9, Name = "Ronin Jiu Jitsu", Address = "1010 W Fremont St, Stockton, CA 95203" },
            new SchoolsModel { Id = 10, Name = "Ernie Reyes West Coast Martial Arts", Address = "1820 E Hammer Ln, Stockton, CA 95210" },
            new SchoolsModel { Id = 11, Name = "Strive Jiu Jitsu & Fitness Academy", Address = "651 N Cherokee Ln Suite E, Lodi, CA 95240" },
            new SchoolsModel { Id = 12, Name = "JG ACADEMY - MANTECA", Address = "125 W Louise Ave, Manteca, CA 95337" },
            new SchoolsModel { Id = 13, Name = "JG ACADEMY - LODI", Address = "2314 W Kettleman Ln Suite 108, Lodi, CA 95242" },
            new SchoolsModel { Id = 14, Name = "Cortez Full Circle Martial Arts", Address = "17800 Murphy Pkwy, Lathrop, CA 95330" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_schools);
        }

        [HttpGet("{Name}")]
        public IActionResult GetBySchoolName(string name)
        {
            var school = _schools.FirstOrDefault(s => s.Name == name);
            if (school == null)
            {
                return NotFound();
            }
            return Ok(school);
        }

        // [HttpGet]
        // [Route("SchoolList/{query}")]
        // public IEnumerable<SchoolsModel> schoolsList(string query)
        // {
        //     // Filter the list of schools based on the search query
        //     var filteredSchools = _schools.Where(s => s.Name.Contains(query));

        //     return filteredSchools;
        // }

    }

}
