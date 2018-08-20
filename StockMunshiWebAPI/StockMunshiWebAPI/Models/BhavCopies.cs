using System;
using System.Collections.Generic;

namespace StockMunshiWebAPI.Models
{
    public partial class BhavCopies
    {
        public long Id { get; set; }
        public string Ticker { get; set; }
        public string Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
    }
}
