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

        public IEnumerable<SchoolsModel> GetItemsByName(string Name)
        {
            return _context.SchoolInfo.Where(item => item.Name == Name);
        }

    }
}