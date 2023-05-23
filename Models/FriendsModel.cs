using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thepathbackend.Models
{
    public class FriendsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendUserId { get; set; }
        public bool isAccepted { get; set; }      
        public bool isDenied { get; set; }
        public FriendsModel(){}
    }
} 