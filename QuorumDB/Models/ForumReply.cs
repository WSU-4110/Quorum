using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuorumDB.Models
{
    public class ForumReply
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("ForumId")]
        public int ForumId { get; set; }
        
        [MaxLength(450)]
        public string UserId { get; set; }

        [MaxLength(256)]
        public int LikeCount{ get; set; }

        public DateTime CreatedTime { get; set; }

        [ForeignKey("UserId")]
        public AspNetUser AspNetUser { get; set; }
    }
}
