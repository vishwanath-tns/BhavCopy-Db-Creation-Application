using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BhavCopyApplication
{
    public class BhavCopy
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public DateTime date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public double Volume { get; set; }

    }
    public class BhavcopyContext : DbContext
    {
        public DbSet<BhavCopy> BhavCopies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BhavCopies.db");
        }
    }

    
}
