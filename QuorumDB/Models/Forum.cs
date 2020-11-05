using QuorumDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace QuorumDB.Models
{
    public class Forum
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; } = "";

        [MaxLength(450)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        public int ViewCount { get; set; }

        public string Description { get; set; }
                
        public string Group { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool IsPrivate { get; set; } = false;

        public List<Forum> ChildForums { get; set; }
        
        public List<ForumMod> Mods { get; set; }
        
        public List<ForumReply> ForumReplies { get; set; }

        [ForeignKey("UserId")]
        public AspNetUser AspNetUserModel { get; set; }


    }
}
