using Microsoft.EntityFrameworkCore;

namespace APINewsFeed.DAL.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<Post> post { get; set; }
        public DbSet<FavoritePost> favoritePost { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(u => u.user)
                .WithMany(p => p.posts)
                .HasForeignKey(k => k.userId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<FavoritePost>()
           .HasKey(ct => new { ct.userId, ct.postId });

            modelBuilder.Entity<FavoritePost>()
                .HasOne(ct => ct.user)
                .WithMany(u => u.favoritePosts)
                .HasForeignKey(ct => ct.userId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoritePost>()
                .HasOne(ct => ct.post)
                .WithMany(t => t.favoritePosts)
                .HasForeignKey(ct => ct.postId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
