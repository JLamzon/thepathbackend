// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using thepathbackend.Models;
// using thepathbackend.Models.DTO;
// using thepathbackend.Services;


// namespace thepathbackend.Controllers
// {
//     [Route("[controller]")]
//     public class FriendsController : Controller
//     {

//         private readonly FriendService _data;

//         public FriendsController(FriendService dataFromService)
//         {
//             _data = dataFromService;
//         }


//         [HttpGet]
//         [Route("GetItemsByFriendId")]


//         public IEnumerable<FriendsModel> GetItemsByFriends()
//         {
//             return _data.GetBlogItemsByFriends();
//         }




//         // [HttpGet]
//         // [Route("GetItemsByFriendId/{UserId}")]

//         // public IEnumerable<FriendsModel> GetBlogItemsByFriendId(int userId)
//         // {
//         //     return _data.GetBlogItemsByFriendId(userId);
//         // }




//         // [HttpGet]
//         // [Route("GetFriendsList")]

//         // public IEnumerable<FriendsModel> GetAllBlogItems()
//         // {
//         //     return _data.GetBlogItemsBy();
//         // }


//         // [HttpGet]
//         // [Route("GetFriend")]

//         // public IEnumerable<FriendsModel> GetFriendById()
//         // {
//         //     return _data.GetFriendById();
//         // }


//     }
// }