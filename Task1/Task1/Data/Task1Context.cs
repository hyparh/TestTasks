using Task1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Task1.Data
{      
    public class Task1Context : DbContext
    {
        public Task1Context()
        {
        }

        public Task1Context(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<MovieStar> MovieStars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-8VBNUMC\SQLEXPRESS;Database=TestTask1;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}