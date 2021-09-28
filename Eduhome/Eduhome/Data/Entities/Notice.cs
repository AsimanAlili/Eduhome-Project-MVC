using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Data.Entities
{
    public class Notice:BaseEntity
    {
        [StringLength(maximumLength: 1500, ErrorMessage = "Length no more than 1500!")]
        public string Desc { get; set; }
    }
}
