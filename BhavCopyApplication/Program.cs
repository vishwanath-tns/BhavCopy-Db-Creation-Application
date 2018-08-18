using System;
using System.Collections.Generic;

namespace BhavCopyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            

            

            using(var db = new BhavcopyContext())
            {
                CsvFilesEnumerator csvEnumerator = new CsvFilesEnumerator(@"D:\bhav copies\temp\");
                List<string> bhavCopyFiles = csvEnumerator.EnumerateCSVFiles();
                foreach(string bcFile in bhavCopyFiles)
                {
                    BhavCopyReader bhavreader = new BhavCopyReader(bcFile);
                    List<BhavCopy> bhavCopies = bhavreader.GetAllRecords();
                    db.BhavCopies.AddRange(bhavCopies);
                    db.SaveChanges();
                }
                
            }
            
        }
    }
}
