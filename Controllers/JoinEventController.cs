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
        [Route("JoinEvent/{userId}")]
        public bool AddAFriend(JoinEventModel joinEvent)
        {
            return _data.JoinEvent(joinEvent);
        }

        [HttpPost]
        [Route("GetAllJoinedEvents")]
        public IEnumerable<JoinEventModel> GetAllEventsJoined()
        {
            return _data.GetAllEventsJoined();
        }
        
    }
}