using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Subscribe:BaseEntity
    {
        
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
