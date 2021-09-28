using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string Name { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Order { get; set; }
        public bool IsDeleted { get; set; }

        public List<Course> Courses { get; set; }
        public List<Event> Events { get; set; }

    }
}
