using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Setting
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Logo { get; set; }

        [NotMapped]
        public IFormFile LogoFile { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string FooterLogo { get; set; }

        [NotMapped]
        public IFormFile FooterLogoFile { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Length no more than 500!")]
        public string FooterDesc { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Title { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "Length no more than 20!")]
        public string ServicePhone { get; set; }


        [StringLength(maximumLength: 20, ErrorMessage = "Length no more than 20!")]
        public string Phone { get; set; }

        [StringLength(maximumLength: 250, ErrorMessage = "Length no more than 250!")]
        public string Address { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Email { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string WebSiteUrl { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string FacebookUrl { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string TwitterUrl { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string VimeoUrl { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string PinteresUrl { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "Length no more than 200!")]
        public string VideoUrl { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string AboutPhoto { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string AboutTitle { get; set; }

        [StringLength(maximumLength: 2500, ErrorMessage = "Length no more than 2500!")]
        public string AboutDesc { get; set; }

        [NotMapped]
        public IFormFile AboutFile { get; set; }


        [NotMapped]
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
