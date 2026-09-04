using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlazorBlog.Models.Tables
{
    public class BlogDBContext : DbContext
    {
        BlogDBContext() 
        { 
        }

        BlogDBContext(DbContextOptions<BlogDBContext> options) 
            : base(options) 
        { 
        }

        public virtual DbSet<PostsTable> Posts { get; set; }
        public virtual DbSet<CommentsTable> Comments { get; set; }
        public virtual DbSet<UsersTable> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostsTable>()
                .HasMany(p => p.comments)
                .WithOne(c => c.post)
                .HasForeignKey(c => c.postId);

            modelBuilder.Entity<UsersTable>()
                .HasMany(u => u.comments)
                .WithOne(c => c.author)
                .HasForeignKey(c => c.authorId);
        }


    }
}
