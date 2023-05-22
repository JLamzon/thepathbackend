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


        public IEnumerable<FriendsModel> GetAllUserFriendsList(int userId)
        {
            return _context.FriendInfo.Where(friend => friend.UserId == userId || friend.FriendUserId == userId);
        }


        public IEnumerable<int> GetUserFriends(int userId)
        {
            var friendIds = new List<int>();
            var friendModels = _context.FriendInfo.Where(friend => friend.UserId == userId && friend.isAccepted == true || friend.FriendUserId == userId && friend.isAccepted == true).ToList();

            foreach (var friendModel in friendModels)
            {
                if (friendModel.UserId == userId)
                {
                    friendIds.Add(friendModel.FriendUserId);
                }
                else
                {
                    friendIds.Add(friendModel.UserId);
                }
            }
            return friendIds;
        }



        public bool DoesFriendExist(int userId, int friendUserId)
        {
            return _context.FriendInfo.SingleOrDefault(friend => friend.UserId == userId && friend.FriendUserId == friendUserId) != null;
        }


        //add a friend
        public bool AddAFriend(FriendsModel newFriendItem)
        {
            if (DoesFriendExist(newFriendItem.UserId, newFriendItem.FriendUserId) || DoesFriendExist(newFriendItem.FriendUserId, newFriendItem.UserId))
            {
                return false;
            }

            _context.FriendInfo.Add(newFriendItem);
            return _context.SaveChanges() != 0;
        }


        //add or deny friend
        public bool UpdateFriendItem(FriendsModel friend)
        {
            FriendsModel? existingFriend = _context.FriendInfo
                .FirstOrDefault(f => (f.UserId == friend.UserId && f.FriendUserId == friend.FriendUserId)
                                     || (f.UserId == friend.FriendUserId && f.FriendUserId == friend.UserId));

            if (existingFriend != null)
            {
                existingFriend.isAccepted = true;
            }
            else
            {
                _context.FriendInfo.Add(friend);
            }

            _context.SaveChanges();
            return true;
        }




        // public bool DeleteFriend(FriendsModel isDeleted)
        // {


        //     if (DoesFriendExist(isDeleted.UserId, isDeleted.FriendUserId) || DoesFriendExist(isDeleted.FriendUserId, isDeleted.UserId))
        //     {
        //         isDeleted.isAccepted = false;
        //         _context.SaveChanges();
        //         return true;
        //     }

        //     return false;
        // }

        public bool DeleteFriend(FriendsModel isDeleted)
        {
            FriendsModel? existingFriend = _context.FriendInfo
                .FirstOrDefault(f => f.UserId == isDeleted.UserId && f.FriendUserId == isDeleted.FriendUserId);

            if (existingFriend != null)
            {
                existingFriend.isAccepted = false;
                _context.SaveChanges();
                return true;
            }

            return false; // If the friendship doesn't exist, return false.
        }


    }
}