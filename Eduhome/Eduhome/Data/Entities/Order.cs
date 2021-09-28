using Eduhome.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Order:BaseEntity
    {
        public string AppUserId { get; set; }
        public int CourseId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public OrderStatus Status { get; set; }

        public AppUser AppUser { get; set; }
        public Course Course { get; set; }
    }
}
