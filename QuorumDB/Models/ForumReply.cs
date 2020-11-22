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
        public int ThreadId { get; set; }
        
        [MaxLength(450)]
        public string UserId { get; set; }

        [MaxLength(450)]
        public string UserName { get; set; }

        [MaxLength(256)]
        public int LikeCount{ get; set; }

        [Required]
        public string Text { get; set; }

        public DateTimeOffset CreatedTime { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public AspNetUser AspNetUserModel { get; set; }

        [ForeignKey("ThreadId")]
        public ForumThread ParentThread { get; set; }
    }
}
