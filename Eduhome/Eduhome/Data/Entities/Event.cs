using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Event:BaseEntity
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Length no more than 150!")]
        public string Title { get; set; }

        [StringLength(maximumLength: 5000, ErrorMessage = "Length no more than 5000!")]
        public string Desc { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Photo { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "Length no more than 200!")]
        public string Venue { get; set; }

        public DateTime Date { get; set; }
        
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public int[] TagIds { get; set; }
        public List<EventTag> EventTags { get; set; }

        [NotMapped]
        public int[] TeacherIds { get; set; }
        public List<EventTeacher> EventTeachers { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public List<EventReview> EventReviews { get; set; }
    }
}
