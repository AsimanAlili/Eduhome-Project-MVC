using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.ViewModels
{
    public class MemberRegisterViewModel
    {
        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 20, ErrorMessage = "Length no more than 20!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = ("This is mandatory!"))]
        [StringLength(maximumLength: 20, ErrorMessage = "Length no more than 20!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "Length no more than 20!")]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
