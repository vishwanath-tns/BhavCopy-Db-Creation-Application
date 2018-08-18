using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CsvHelper;
using System.Linq;
using System.Globalization;

namespace BhavCopyApplication
{
    public class BhavCopyReader
    {
        private string filename;
        public BhavCopyReader(string csvfilename)
        {
            filename = csvfilename;
        }
        public List<BhavCopy> GetAllRecords()
        {
            using (StreamReader reader = File.OpenText(filename))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.HeaderValidated = null;
                csvReader.Configuration.MissingFieldFound = null;
                //csvReader.Configuration. = false;
                //var countries = csvReader.GetRecords<BhavCopy>().ToList();
                List<BhavCopy> bhavCopies = new List<BhavCopy>();
                while( csvReader.Read() )
                {
                    BhavCopy bc = new BhavCopy();
                    var Ticker = csvReader[0];
                    bc.Ticker = Ticker.ToString();

                    var date = csvReader[1];
                    bc.date = DateTime.ParseExact(date.ToString(),"MMddyyyy",CultureInfo.InvariantCulture);

                    var open = csvReader[2];
                    if (open == "")
                        bc.Open = 0;
                    else
                        bc.Open = Convert.ToDouble(open);
                    
                    var High = csvReader[3];
                    if (High == "")
                        bc.High = 0;
                    else
                        bc.High = Convert.ToDouble(High);
                    
                    var Low = csvReader[4];
                    if (Low == "")
                        bc.Low = 0;
                    else
                        bc.Low = Convert.ToDouble(Low);

                    var Close = csvReader[5];
                    if (Close == "")
                        bc.Close = 0;
                    else
                        bc.Close = Convert.ToDouble(Close);

                    var Volume = csvReader[6];
                    if (Volume == "")
                        bc.Volume = 0;
                    else
                        bc.Volume = Convert.ToDouble(Volume);

                    bhavCopies.Add(bc);
                }
                
                
                return bhavCopies;
            }
            
        }
    }
}