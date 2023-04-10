using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thepathbackend.Models;
using thepathbackend.Services.Context;

namespace thepathbackend.Services
{
    public class AcademyEventService
    {
        private readonly DataContext _context;

        public AcademyEventService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<AcademyEventsModel> GetAllEventItems()
        {
            return _context.EventInfo.Where(item => item.isPublish);
        }

        public bool CreateEventItem(AcademyEventsModel newEventItem)
        {
            _context.Add(newEventItem);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateEventItem(AcademyEventsModel EventUpdate){
            _context.Update<AcademyEventsModel>(EventUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool DeleteEventItem(AcademyEventsModel EventDelete)
        {
            EventDelete.isDeleted = true;
            _context.Update<AcademyEventsModel>(EventDelete);
            return _context.SaveChanges() != 0;
        }


        //         public AcademyEventsModel GetEventItemById(int id)
        // {
        //     return _context.EventInfo.SingleOrDefault(item => item.Id == id);
        // }


    }
}