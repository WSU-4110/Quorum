﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuorumDB.Models;

namespace Quorum.Data
{
    public class ApplicationDbContext : IdentityDbContext<AspNetUser>
    {
        private static ApplicationDbContext Instance = new ApplicationDbContext();

        private ApplicationDbContext() : base() { }

        public static ApplicationDbContext GetInstance()
        {
            return Instance;
        }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumReply> ForumReplies { get; set; }
        public DbSet<ForumMod> Mod { get; set; }
        
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<ForumsFollowed> ForumsFollowed { get; set; }
        public DbSet<UsersFollowed> UsersFollowed { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Forum>()
                .HasIndex(f => f.Url);
        }
    }
}
