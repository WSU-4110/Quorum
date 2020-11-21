using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuorumDB.Models
{
    public class AspNetUser : IdentityUser
    {   
        [MaxLength(512)]
        public string AvatarUrl { get; set; }

        public DateTimeOffset DateRegistered { get; set; }
    } 
}
