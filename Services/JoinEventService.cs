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
    public class JoinEventService
    {
         private readonly DataContext _context;


        public JoinEventService(DataContext context)
        {
            _context = context;
        }


        //Join Event
            public bool JoinEvent(JoinEventModel joinEventItem)
        {
            joinEventItem.isJoined = false;
            _context.JoinEventInfo.Add(joinEventItem);
            return _context.SaveChanges() != 0;
        }

        //GetAllJoinedEvents
            public IEnumerable<JoinEventModel> GetAllEventsJoined()
        {
            return _context.JoinEventInfo;
        }

        //GetAllEventsByUserId
        public IEnumerable<JoinEventModel> GetAllEventsByUserId(int userId)
        {
            return _context.JoinEventInfo.Where(events => events.UserId == userId);
        }



        //GetAllEventsJoinedByUserId


    }
}