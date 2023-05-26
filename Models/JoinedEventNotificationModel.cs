using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace thepathbackend.Models
{
    public class JoinedEventNotificationModel
    {
        [Key]
        public int Id { get; set; }
        public int eventId { get; set; }
        public int createdUserId { get; set; }
        public int joinedUserId { get; set; }
        public bool isSeen { get; set; }
        public JoinedEventNotificationModel() { }
    }
}