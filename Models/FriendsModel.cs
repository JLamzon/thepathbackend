using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thepathbackend.Models
{
    public class FriendsModel
    {
        public int? Id { get; set; }
        public string? FriendId { get; set; }
        public string? FriendUserId { get; set; }
        public bool? isAccepted { get; set; }
    }
}