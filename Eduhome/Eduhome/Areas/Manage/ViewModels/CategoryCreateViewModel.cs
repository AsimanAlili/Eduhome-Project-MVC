using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Areas.Manage.ViewModels
{
    public class CategoryCreateViewModel
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string Name { get; set; }

        [Range(minimum: 0, maximum: int.MaxValue)]
        public int Order { get; set; }
    }
}
