using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thepathbackend.Models
{
    public class AcademyEventsModel
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PublishedName { get; set; }
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public bool isPublish { get; set; }
        public bool isDeleted { get; set; }
        public string? image { get; set; }

        public AcademyEventsModel() { }
    }
}