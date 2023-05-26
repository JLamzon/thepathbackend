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
    public class JoinEventNotificationService
    {
        private readonly DataContext _context;


        public JoinEventNotificationService(DataContext context)
        {
            _context = context;
        }

        //Join Event
        public bool JoinNotification(JoinedEventNotificationModel joinEventNotificationItem)
        {
            joinEventNotificationItem.isSeen = false;
            _context.JoinEventNotificationInfo.Add(joinEventNotificationItem);
            return _context.SaveChanges() != 0;
        }

        public bool JoinNotificationUpdate(JoinedEventNotificationModel joinEventItem)
        {
            var existingEvent = _context.JoinEventNotificationInfo.FirstOrDefault(e =>
                e.eventId == joinEventItem.eventId &&
                e.createdUserId == joinEventItem.createdUserId &&
                e.joinedUserId == joinEventItem.joinedUserId);
            if (existingEvent != null)
            {
                existingEvent.isSeen = true;
                return _context.SaveChanges() != 0;
            }

            return false; // Return false if the entity to update is not found
        }



        // public bool updateNotification(JoinedEventNotificationModel notify)
        // {
        //     JoinedEventNotificationModel? newNotification = _context.JoinEventNotificationInfo
        //         .FirstOrDefault(f => (f.createdUserId == notify.createdUserId && f.joinedUserId == notify.joinedUserId)
        //                              || (f.createdUserId == notify.joinedUserId && f.joinedUserId == notify.createdUserId));
        //     if (newNotification != null)
        //     {
        //         if (notify.isSeen)
        //         {
        //             newNotification.isSeen = true;
        //         }
        //         else if (notify.isSeen)
        //         {
        //             newNotification.isSeen = false;
        //         }
        //     }
        //     else
        //     {
        //         _context.JoinEventNotificationInfo.Add(notify);
        //     }

        //     _context.SaveChanges();
        //     return true;
        // }



        //GetAllJoinedEvents
        public IEnumerable<JoinedEventNotificationModel> GetAllEventNotifications()
        {
            return _context.JoinEventNotificationInfo;
        }

        //GetAllEventsByUserId
        public IEnumerable<JoinedEventNotificationModel> GetAllEventsByUserId(int createdUserId)
        {
            return _context.JoinEventNotificationInfo.Where(notification => notification.createdUserId == createdUserId);
        }
    }
}