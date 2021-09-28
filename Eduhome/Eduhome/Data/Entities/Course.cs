using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Course:BaseEntity
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Name { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Photo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "Length no more than 120!")]
        public string Slug { get; set; }

        [StringLength(maximumLength: 1500, ErrorMessage = "Length no more than 1500!")]
        public string Desc { get; set; }

        [StringLength(maximumLength: 1500, ErrorMessage = "Length no more than 1500!")]
        public string AboutDesc { get; set; }

        [StringLength(maximumLength: 1500, ErrorMessage = "Length no more than 1500!")]
        public string ApplyDesc { get; set; }

        [StringLength(maximumLength: 1500, ErrorMessage = "Length no more than 1500!")]
        public string CertificationDesc { get; set; }

        public DateTime Start { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Duration { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Hours { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string SkillLevel { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Language { get; set; }
        public int Student { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<CourseTag> CourseTags { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        [NotMapped]
        public int[] TagIds { get; set; }

        public List<CourseReview> CourseReviews { get; set; }
        public List<Order> Orders { get; set; }

    }
}
