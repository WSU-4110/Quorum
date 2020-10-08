using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuorumDB.Models
{
    public class ForumMod
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(256)]
        //[Column(TypeName = "varchar(10)")]
        public int ForumModelId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser IdentityUser;
    }
}
