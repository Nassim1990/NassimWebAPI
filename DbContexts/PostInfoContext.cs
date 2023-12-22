using Microsoft.EntityFrameworkCore;
using NassimWebAPI.Entities;

namespace NassimWebAPI.DbContexts
{
    public class PostInfoContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public PostInfoContext(DbContextOptions<PostInfoContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category()
                {
                    Id = 1,
                    Name = "General",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Technology",
                },
                new Category()
                {
                    Id = 3,
                    Name = "Random",
                });


            base.OnModelCreating(modelBuilder);
        }

    }
}
