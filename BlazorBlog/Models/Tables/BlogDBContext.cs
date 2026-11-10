using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlazorBlog.Models.Tables
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext() 
        {
        }

        public BlogDBContext(DbContextOptions<BlogDBContext> options) 
            : base(options) 
        { 
        }

        public virtual DbSet<PostsTable> Posts { get; set; }
        public virtual DbSet<CommentsTable> Comments { get; set; }
        public virtual DbSet<UsersTable> Users { get; set; }
        public virtual DbSet<TagsTable> Tags { get; set; }
        public virtual DbSet<CathegoriesTable> Cathegories { get; set; }
        public virtual DbSet<PostsToTagsTable> PostToTags { get; set; }
        public virtual DbSet<PostsToCathegoriesTable> PostToCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //PRIMARY KEYS
            //
            modelBuilder.Entity<PostsTable>().HasKey(p => p.id);
            modelBuilder.Entity<UsersTable>().HasKey(u => u.id);
            modelBuilder.Entity<CommentsTable>().HasKey(c => c.id);
            modelBuilder.Entity<TagsTable>().HasKey(t => t.id);
            modelBuilder.Entity<CathegoriesTable>().HasKey(ct => ct.id);
            modelBuilder.Entity<PostsToTagsTable>().HasKey(pt => pt.id);
            modelBuilder.Entity<PostsToCathegoriesTable>().HasKey(ptc => ptc.id);

            //TABLE RELATIONSHIPS
            //
            // ── POST → COMMENTS (one-to-many) ─────────────────────────
            modelBuilder.Entity<PostsTable>()
                .HasMany(p => p.comments)
                .WithOne(c => c.post)
                .HasForeignKey(c => c.postId);

            // ── USERS → COMMENTS (one-to-many) ───────────────────────
            modelBuilder.Entity<UsersTable>()
                .HasMany(u => u.comments)
                .WithOne(c => c.author)
                .HasForeignKey(c => c.authorId);

            // ── POSTS ↔ TAGS (many-to-many) ─────────────────
            modelBuilder.Entity<PostsTable>()
                .HasMany(p => p.postToTags)                    
                .WithOne(pt => pt.post)
                .HasForeignKey(pt => pt.PostId);

            // ── TAGS ↔ POST TO TAGS ──────────
            modelBuilder.Entity<TagsTable>()
                .HasMany(t => t.PostToTags)
                .WithOne(pt => pt.tag)
                .HasForeignKey(pt => pt.TagId);

            // ── POSTS ↔ CATHEGORIES (many-to-many) ──────────
            modelBuilder.Entity<PostsTable>()
                .HasMany(p => p.PostToCathegory)              
                .WithOne(ptc => ptc.post)
                .HasForeignKey(ptc => ptc.postId);

            // ── CATEGORIES ↔ POST TO CATEGORIES ──────────
            modelBuilder.Entity<CathegoriesTable>()
                .HasMany(ct => ct.PostToCathegory)
                .WithOne(ptc => ptc.cathegory)
                .HasForeignKey(ptc => ptc.cathegoryId);

            // COMMENT RESPONSES (one-to-many) ──────────
            modelBuilder.Entity<CommentsTable>()
                .HasMany(c => c.responsesToComment)          
                .WithOne(c => c.responseToComment)           
                .HasForeignKey(c => c.responseToCommentId);
        }
    }
}
