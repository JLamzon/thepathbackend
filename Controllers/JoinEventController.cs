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

    public class JoinEventController
    {
        private readonly JoinEventService _data;

        public JoinEventController(JoinEventService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpPost]
        [Route("JoinEvent/{eventId}/{userId}")]
        public bool JoinEvent(JoinEventModel userJoined)
        {
            return _data.JoinEvent(userJoined);
        }

        [HttpGet]
        [Route("GetAllEventsByUserId/{userId}")]
        public IEnumerable<JoinEventModel> GetAllEventsByUserId(int userId)
        {
            return _data.GetAllEventsByUserId(userId);
        }

        [HttpGet]
        [Route("GetAllEventsJoined")]
        public IEnumerable<JoinEventModel> GetAllEventsJoined()
        {
            return _data.GetAllEventsJoined();
        }
    }
}