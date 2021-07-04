using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace PlsAPI.Models
{
    public partial class CCAIContext : DbContext
    {
        public CCAIContext(DbContextOptions<CCAIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<One> One { get; set; }
        public virtual DbSet<Two> Two { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
