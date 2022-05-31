using GameCenter.Models.Genre;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNull] DbContextOptions options) : base(options)
        { }

        public DbSet<Genre> Genres { get; set; }
    }
}
