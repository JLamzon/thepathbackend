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

        public FriendsModel(){}

        // public FriendsModel(int id, string friendId, string friendUserId, bool Accepted){
        //     Id = id;
        //     FriendId = friendId;
        //     FriendUserId = friendUserId;
        //     isAccepted = Accepted;
        // }
    }
}