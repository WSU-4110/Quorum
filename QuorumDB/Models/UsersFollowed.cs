using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuorumDB.Models
{
    public class UsersFollowed
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string FollowedUserId { get; set; }

        [ForeignKey("UserId")]
        public AspNetUser AspNetUserModel { get; set; }

        [ForeignKey("FollowedUserId")]
        public AspNetUser AspNetFollowedUserModel { get; set; }
    }
}
