using System;
using System.Collections.Generic;

namespace BhavCopyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int fileCount = 50;
            using(var db = new BhavcopyContext())
            {
                CsvFilesEnumerator csvEnumerator = new CsvFilesEnumerator(@"D:\bhav copies\temp\");
                List<string> bhavCopyFiles = csvEnumerator.EnumerateCSVFiles();
                Log BhavCopyImportLog = new Log(Environment.CurrentDirectory,"BhavCopyImport.txt");
                List<BhavCopy> BatchBhavList = new List<BhavCopy>();
                int BatchSize = 100;
                foreach(string bcFile in bhavCopyFiles)
                {
                    try
                    {
                        
                        BhavCopyReader bhavreader = new BhavCopyReader(bcFile);
                        List<BhavCopy> bhavCopies = bhavreader.GetAllRecords();
                        //throw new Exception("Exception");
                        if(fileCount % BatchSize == 0)
                        {
                            BatchBhavList.AddRange(bhavCopies);
                            db.BhavCopies.AddRange(BatchBhavList);
                            db.SaveChanges();
                            BatchBhavList.Clear();
                        }
                        else
                        {
                            BatchBhavList.AddRange(bhavCopies);
                        }
                            
                        
                        fileCount++;
                        Console.WriteLine($"{fileCount} of {bhavCopyFiles.Count} imported");
                    }
                    catch (System.Exception exp)
                    {
                        string logMessage = "Import Error ";
                        logMessage += Environment.NewLine;
                        logMessage += bcFile;
                        logMessage += Environment.NewLine;
                        logMessage += exp.Message;
                        BhavCopyImportLog.WriteToLog(logMessage);
                        Console.WriteLine($"Exception : {logMessage}");


                        continue;
                    }
                    
                }
                if(BatchBhavList.Count > 0)
                {
                    db.BhavCopies.AddRange(BatchBhavList);
                    db.SaveChanges();
                    BatchBhavList.Clear();
                }                
            }
            
        }
    }
}
