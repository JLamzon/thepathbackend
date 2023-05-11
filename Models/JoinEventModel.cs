using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thepathbackend.Models
{
    public class JoinEventModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public bool isJoined { get; set; }
        public JoinEventModel(){}
    }
}