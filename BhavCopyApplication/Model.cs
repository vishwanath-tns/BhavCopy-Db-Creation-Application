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
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
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
