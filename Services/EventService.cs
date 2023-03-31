using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thepathbackend.Models;
using thepathbackend.Services.Context;

namespace thepathbackend.Services
{
    public class EventService
    {
        private readonly DataContext _context;

        public EventService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<EventItemModel> GetItemsByTitle(string title)
        {
            return _context.EventInfo.Where(item => item.Title == title);
        }

        // public IEnumerable<EventItemModel> GetItemsByDate(string date)
        // {
        //     return _context.EventInfo.Where(item => item.Date == date);
        // }

    }
}