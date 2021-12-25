using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MyWebAPI.Models
{
    public class response3Context : DbContext
    {
        public response3Context(DbContextOptions<response3Context> options)
            : base(options) { }

        public DbSet<response3> response3Items { get; set; } = null!;
    }
}
