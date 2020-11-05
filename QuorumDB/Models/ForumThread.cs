using QuorumDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuorumDB.Models
{
    public class ForumThread
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ForumId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [ForeignKey("ForumId")]
        public Forum ForumModel { get; set; }

        [ForeignKey("UserId")]
        public AspNetUser AspNetUserModel { get; set; }

    }
}
