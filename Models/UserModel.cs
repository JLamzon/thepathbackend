using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace thepathbackend.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AboutMe { get; set; }
        public string? image { get; set; }
        public string? AcademyName { get; set; }
        public string? Belt { get; set; }
         [JsonIgnore]
        public string? Hash { get; set; }
         [JsonIgnore]
        public string? salt { get; set; }

        public bool HasPasswordChanged { get; set; }

        public UserModel(){
            HasPasswordChanged = false;
        }
    }
}