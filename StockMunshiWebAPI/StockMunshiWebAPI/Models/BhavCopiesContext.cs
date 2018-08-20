using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockMunshiWebAPI.Models
{
    public partial class BhavCopiesContext : DbContext
    {
        public BhavCopiesContext()
        {
        }

        public BhavCopiesContext(DbContextOptions<BhavCopiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BhavCopies> BhavCopies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource = D:\\Study\\Entity Framework\\Code\\SQL Lite and EF Core\\BhavCopyApplication\\BhavCopies.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BhavCopies>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date");
            });
        }
    }
}
