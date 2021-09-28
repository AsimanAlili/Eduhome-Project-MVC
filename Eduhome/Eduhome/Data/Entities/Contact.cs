using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Contact:BaseEntity
    {
        [StringLength(maximumLength: 20, ErrorMessage = "Length no more than 20!")]
        public string Phone { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Email { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string WebSiteUrl { get; set; }

        public List<ContactReview> ContactReviews { get; set; }
    }
}
