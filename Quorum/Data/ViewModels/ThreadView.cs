using System.ComponentModel.DataAnnotations;

namespace Quorum.Data.UserModels
{
    public class ThreadView
    {
        [Required(ErrorMessage = "Must enter a title")]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Must enter a description")]
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
