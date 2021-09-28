using Eduhome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.ViewModels
{
    public class AboutViewModel
    {
        public List<Testimonial> Testimonials { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Notice> Notices { get; set; }
    }
}
