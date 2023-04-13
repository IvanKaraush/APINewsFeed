﻿using Microsoft.EntityFrameworkCore;

namespace APINewsFeed.DAL.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<Post> post { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(u => u.user)
                .WithMany(p => p.posts)
                .HasForeignKey(k => k.userId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
