using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thepathbackend.Models;
using thepathbackend.Models.DTO;
using thepathbackend.Services.Context;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace thepathbackend.Services
{
    public class FriendService
    {
        private readonly DataContext _context;
        public FriendService(DataContext context)
        {
            _context = context;
        }

        //get all friends
        public IEnumerable<FriendsModel> GetAllFriends()
        {
            return _context.FriendInfo;
        }

        //add a friend
        public bool AddAFriend(FriendsModel newFriendItem)
        {
             newFriendItem.Id = _context.FriendInfo.Max(f => f.Id) + 1;
            _context.FriendInfo.Add(newFriendItem);
            return _context.SaveChanges() != 0;
        }

        


        //post a friend id


        //get a friend


        //deny a friend



    }
}