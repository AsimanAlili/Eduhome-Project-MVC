using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Testimonial:BaseEntity
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string FullName { get; set; }

        [StringLength(maximumLength: 2500, ErrorMessage = "Length no more than 2500!")]
        public string Desc { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string Occupation { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string Place { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Photo { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
