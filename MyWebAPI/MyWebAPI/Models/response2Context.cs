using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MyWebAPI.Models
{
    public class response2Context : DbContext
    {
        public response2Context(DbContextOptions<response2Context> options)
            : base(options) { }

        public DbSet<response2> response2Items { get; set; } = null!;
    }
}
