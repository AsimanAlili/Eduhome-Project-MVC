using Eduhome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.ViewModels
{
    public class CourseDetailViewModel
    {
        public Course Course { get; set; }
        public List<Course> Courses { get; set; }
        public List<Category> Categories { get; set; }
    }
}
