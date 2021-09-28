using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class EventReview:BaseEntity
    {
        public int EventId { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string FullName { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!"), DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Length no more than 500!")]
        public string Subject { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Length no more than 500!")]

        public string Message { get; set; }

        public Event Event { get; set; }
    }
}
