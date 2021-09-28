using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 20, ErrorMessage = "Length no more than 20!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 20, ErrorMessage = "Length no more than 20!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
