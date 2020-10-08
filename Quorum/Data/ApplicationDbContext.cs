using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuorumDB.Models;

namespace Quorum.Data
{
    //public class ApplicationDbContext : IdentityDbContext<AspNetUserModel>
    public class ApplicationDbContext : IdentityDbContext<AspNetUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Forum> ForumModels { get; set; }
        public DbSet<ForumReply> ForumReplies { get; set; }
        public DbSet<ForumMod> Mod { get; set; }
   
    }
}
