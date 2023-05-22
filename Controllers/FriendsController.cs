using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using thepathbackend.Models;
using thepathbackend.Models.DTO;
using thepathbackend.Services;


namespace thepathbackend.Controllers
{
    [Route("[controller]")]
    public class FriendsController : Controller
    {
        private readonly FriendService _data;

        public FriendsController(FriendService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpGet]
        [Route("GetFriendsList")]

        public IEnumerable<FriendsModel> GetAllFriends()
        {
            return _data.GetAllFriends();
        }

        [HttpGet]
        [Route("GetAllUserFriendsList/{userId}")]

        public IEnumerable<FriendsModel> GetAllUserFriendsList(int userId)
        {
            return _data.GetAllUserFriendsList(userId);
        }


        [HttpGet]
        [Route("GetUserFriends/{userId}")]
        public IEnumerable<int> GetUserFriends(int userId)
        {
            return _data.GetUserFriends(userId);
        }


        //add a friend
        [HttpPost]
        [Route("AddAFriend/{userId}/{friendUserId}")]
        public bool AddAFriend(FriendsModel newFriendItem)
        {
            return _data.AddAFriend(newFriendItem);
        }

        //friend accept or deny
        [HttpPut]
        [Route("FriendUpdate/{Id}/{userId}/{friendUserId}/{isAccepted}/{isDenied}")]
        public bool UpdateFriendItem(FriendsModel friendUpdate)
        {
            return _data.UpdateFriendItem(friendUpdate);
        }


        [HttpPut]
        [Route("DeleteFriend/{userId}/{friendUserId}")]

        public bool DeleteFriend(FriendsModel deleteFriend)
        {
            return _data.DeleteFriend(deleteFriend);
        }
    }
}