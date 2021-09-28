using Eduhome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.ViewModels
{
    public class TeacherDetailViewModel
    {
        public Teacher Teacher { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
