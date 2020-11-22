using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quorum.Data.UserModels
{
    public class ReplyView
    {
        [Required(ErrorMessage = "Must enter a description")]
        [MaxLength(256)]
        public string Text { get; set; }
    }
}
