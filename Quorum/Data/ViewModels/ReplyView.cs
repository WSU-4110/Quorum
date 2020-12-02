using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quorum.Data.UserModels
{
    public class ReplyView
    {
        [Required(ErrorMessage = "Must enter a message")]
        [MaxLength(500, ErrorMessage = "Please enter less than 500 characters")]
        public string Text { get; set; }
    }
}
