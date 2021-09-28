using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Tag:BaseEntity
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string Name { get; set; }

        public List<CourseTag> CourseTags { get; set; }
        public List<EventTag> EventTags { get; set; }

    }
}
