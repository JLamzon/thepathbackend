using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thepathbackend.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Hash { get; set; }
        public string? salt { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AboutMe { get; set; }
        public string? image { get; set; }

        public UserModel(){}
    }
}