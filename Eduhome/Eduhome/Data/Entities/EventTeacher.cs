using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class EventTeacher
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int TeacherId { get; set; }
        public Event Event { get; set; }
        public Teacher Teacher { get; set; }
    }
}
