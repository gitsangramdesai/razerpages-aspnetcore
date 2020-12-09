using RazorPagesMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RazorPagesMovie.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
           modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.ID);
            });
        }  
    }    
}