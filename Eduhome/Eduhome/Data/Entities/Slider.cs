using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Slider:BaseEntity
    {
        [Required(ErrorMessage =("This is mandatory!"))]
        [StringLength(maximumLength: 150,ErrorMessage = "Length no more than 150!")]
        public string Title { get; set; }

        [StringLength(maximumLength: 350, ErrorMessage = "Length no more than 350!")]
        public string Text { get; set; }

        [StringLength(maximumLength: 350, ErrorMessage = "Length no more than 350!")]
        public string RedirectUrl { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Photo { get; set; }

        public int Order { get; set; }


        [NotMapped]
        public IFormFile File { get; set; }
    }
}
