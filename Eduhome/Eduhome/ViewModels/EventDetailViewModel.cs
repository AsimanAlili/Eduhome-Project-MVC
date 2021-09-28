using Eduhome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.ViewModels
{
    public class EventDetailViewModel
    {
        public Event Event { get; set; }
        public List<Event> Events { get; set; }
        public List<Category> Categories { get; set; }
    }
}
