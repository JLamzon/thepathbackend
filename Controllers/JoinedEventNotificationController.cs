using System;
using System.Collections.Generic;
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
    public class JoinedEventNotificationController
    {
        private readonly JoinEventNotificationService _data;

        public JoinedEventNotificationController(JoinEventNotificationService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpPost]
        [Route("{eventId}/{joinedUserId}/{createdUserId}")]
        public bool JoinEvent(JoinedEventNotificationModel userJoined)
        {
            return _data.JoinNotification(userJoined);
        }

        // [HttpPut]
        // [Route("updateNotification")]
        // public bool JoinNotificationUpdate(JoinedEventNotificationModel userSeen)
        // {
        //     return _data.JoinNotificationUpdate(userSeen);
        // }


        [HttpGet]
        [Route("JoinNotification/{createdUserId}")]
        public IEnumerable<JoinedEventNotificationModel> GetAllEventsByUserId(int createdUserId)
        {
            return _data.GetAllEventsByUserId(createdUserId);
        }


        [HttpGet]
        [Route("GetAllEventsJoined")]
        public IEnumerable<JoinedEventNotificationModel> GetAllEventsJoined()
        {
            return _data.GetAllEventNotifications();
        }
    }
}