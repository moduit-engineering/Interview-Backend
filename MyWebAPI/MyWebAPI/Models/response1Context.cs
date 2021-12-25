using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MyWebAPI.Models
{
    public class response1Context : DbContext
    {
        public response1Context(DbContextOptions<response1Context> options)
            : base(options)
        {
        }

        public DbSet<response1> response1Items { get; set; } = null!;
    }
}
