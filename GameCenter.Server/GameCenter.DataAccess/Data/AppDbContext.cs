using GameCenter.Models.Genre;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GameCenter.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNull] DbContextOptions options) : base(options)
        {}

        public DbSet<Genre> Genres { get; set; }
    }
}