using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thepathbackend.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AboutMe { get; set; }
        public string? image { get; set; }
        public string? AcademyName { get; set; }
        public string? Belt { get; set; }

        public UserProfile(){}
    }
}