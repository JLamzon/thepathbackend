using Microsoft.AspNetCore.Mvc;
using thepathbackend.Models;
using thepathbackend.Services;

namespace thepathbackend.Controllers;

[ApiController]
[Route("[controller]")]

public class AcademyEventsController : ControllerBase
{
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
    public bool CreateEventItem(AcademyEventsModel AddEvent)
    {
        return _data.CreateEventItem(AddEvent);
    }


    [HttpPut]
    [Route("UpdateEvent")]

    public bool UpdateEventItem(AcademyEventsModel EventUpdate)
    {
        return _data.UpdateEventItem(EventUpdate);
    }


    [HttpGet]
    [Route("DeleteEvent")]

    public bool DeleteEventItem(AcademyEventsModel EventDelete)
    {
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



