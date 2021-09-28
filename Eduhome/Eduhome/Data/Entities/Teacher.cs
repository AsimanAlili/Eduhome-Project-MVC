using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Teacher:BaseEntity
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string TeachingStatus { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Length no more than 500!")]
        public string Photo { get; set; }

        [StringLength(maximumLength: 1500, ErrorMessage = "Length no more than 1500!")]
        public string Desc { get; set; }
        
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Degree { get; set; }

       
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Experience { get; set; }


        [StringLength(maximumLength: 150, ErrorMessage = "Length no more than 150!")]
        public string Hobby { get; set; }

       
        [StringLength(maximumLength: 150, ErrorMessage = "Length no more than 150!")]
        public string Faculty { get; set; }


        
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Email { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string PhoneNumber { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Skype { get; set; }

   
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string FacebookUrl { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string PinterestUrl { get; set; }

      
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string VimeoUrl { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string TwitterUrl { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100!")]

        public int LanguagePercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100!")]

        public int TeamLeaderPercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100!")]

        public int DevelopmentPercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100!")]
        public int DesignPercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100!")]
        public int InnovationPercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100!")]
        public int CommunicationPercentage { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public List<EventTeacher> EventTeachers { get; set; }

    }
}
