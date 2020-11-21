using Quorum.Data.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quorum.Data.UserModels
{
    public class ForumView
    {
        internal string ParentForumTitle { get; set; }

        [Required(ErrorMessage = "Must enter a title")]
        [MaxLength(20)]
        //Regex to stop / in the title description
        [RegularExpression("[^/]+", ErrorMessage ="Invalid character")]
        [ForumValidator]
        public string Title { get; set; }

        [Required(ErrorMessage ="Must enter a description")]
        [MaxLength(256)]
        public string Description { get; set; }

        public bool IsPrivate { get; set; } = false;
    }
}
