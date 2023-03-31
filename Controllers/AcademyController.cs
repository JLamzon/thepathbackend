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
    public class AcademyController : ControllerBase
    {
        private static List<AcademyModel> _Academy = new List<AcademyModel>()
        {
            new AcademyModel { Id = 0, Name = "Andre de Freitas Brazilian Jiu-Jitsu", Address = "654 Grider Way B, Stockton, CA 95210" },
            new AcademyModel { Id = 1, Name = "Ares BJJ Stockton - Buffalo Black Brotherhood", Address = "7475 Murray Dr #6, Stockton, CA 95210" },
            new AcademyModel { Id = 2, Name = "VALOR Training Center", Address = "9937 Lower Sacramento Rd, Stockton, CA 95210" },
            new AcademyModel { Id = 3, Name = "Inside BJJ _Academy", Address = "3422 W Hammer Ln suite g, Stockton, CA 95219" },
            new AcademyModel { Id = 4, Name = "Stockton JiuJitsu _Academy", Address = "2222 Grand Canal Blvd #8, Stockton, CA 95207" },
            new AcademyModel { Id = 5, Name = "Stockton Dominate MMA", Address = "6360 Pacific Ave #1, Stockton, CA 95207" },
            new AcademyModel { Id = 6, Name = "Nick Diaz _Academy", Address = "3802 Wilcox Rd, Stockton, CA 95215" },
            new AcademyModel { Id = 7, Name = "10th Planet Stockton", Address = "3422 W Hammer Ln suite g, Stockton, CA 95219" },
            new AcademyModel { Id = 8, Name = "TEAM CAMA", Address = "8909 Thornton Rd #2, Stockton, CA 95209" },
            new AcademyModel { Id = 9, Name = "Ronin Jiu Jitsu", Address = "1010 W Fremont St, Stockton, CA 95203" },
            new AcademyModel { Id = 10, Name = "Ernie Reyes West Coast Martial Arts", Address = "1820 E Hammer Ln, Stockton, CA 95210" },
            new AcademyModel { Id = 11, Name = "Strive Jiu Jitsu & Fitness _Academy", Address = "651 N Cherokee Ln Suite E, Lodi, CA 95240" },
            new AcademyModel { Id = 12, Name = "JG ACADEMY - MANTECA", Address = "125 W Louise Ave, Manteca, CA 95337" },
            new AcademyModel { Id = 13, Name = "JG ACADEMY - LODI", Address = "2314 W Kettleman Ln Suite 108, Lodi, CA 95242" },
            new AcademyModel { Id = 14, Name = "Cortez Full Circle Martial Arts", Address = "17800 Murphy Pkwy, Lathrop, CA 95330" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_Academy);
        }

        [HttpGet("{Name}")]
        public IActionResult GetAcademyByName(string name)
        {
            var school = _Academy.FirstOrDefault(s => s.Name == name);
            if (school == null)
            {
                return NotFound();
            }
            return Ok(school);
        }

        [HttpGet]
        [Route("AcademyList/{query}")]
        public IEnumerable<AcademyModel> GetAcademyList(string query)
        {
            // Filter the list of _Academy based on the search query
            var filteredAcademy = _Academy.Where(s => s.Name.Contains(query));

            return filteredAcademy;
        }
    }
}
