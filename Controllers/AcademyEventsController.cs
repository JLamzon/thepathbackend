using Microsoft.AspNetCore.Mvc;
using thepathbackend.Models;
using thepathbackend.Services;

namespace thepathbackend.Controllers;

[ApiController]
[Route("[controller]")]

    public class AcademyEventsController : ControllerBase
{
    //post
        //no logic in user controller

        //this tells usercontroller we can only read, not write

        private readonly AcademyEventService _data;

        public AcademyEventsController(AcademyEventService dataFromService)
        {
            _data = dataFromService;
        }



        [HttpGet]
        [Route("GetEventItems")]

        public IEnumerable<AcademyEventsModel> GetAllEventItems()
        {
            return _data.GetAllEventItems();
        }


        [HttpPost]
        [Route("CreateEvent")]
        public bool CreateEventItem(AcademyEventsModel newEventItem){
            return _data.CreateEventItem(newEventItem);
        }


        [HttpGet]
        [Route("UpdateEvent")]

        public bool UpdateEventItem(AcademyEventsModel EventUpdate){
            return _data.UpdateEventItem(EventUpdate);
        }



        [HttpGet]
        [Route("DeleteEvent")]

        public bool DeleteEventItem(AcademyEventsModel EventDelete){
            return _data.DeleteEventItem(EventDelete);
        }



        // [HttpGet]
        // [Route("GetAcademyEvents")]

        // public IEnumerable<AcademyEventsModel> GetEventsFromAcademy()
        // {
        //     return _data.GetEventsFromAcademy();
        // }

        
        
        // [HttpGet]
        // [Route("GetFriendsEvents")]


        // public IEnumerable<AcademyEventsModel> GetEventsFromFriends()
        // {
        //     return _data.GetEventsFromFriends();
        // }

    }


    //get
    


