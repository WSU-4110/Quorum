using QuorumDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;



namespace QuorumDB.Models
{
    public class ForumsFollowed
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ForumId { get; set; }

        [ForeignKey("UserId")]
        public AspNetUser AspNetUserModel { get; set; }

        [ForeignKey("ForumId")]
        public Forum parentForum { get; set; }

    }
}
