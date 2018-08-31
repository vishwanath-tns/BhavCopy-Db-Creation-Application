using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMunshiWebAPI.Models;

namespace StockMunshiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousebreakController : ControllerBase
    {
        private readonly BhavCopiesContext _context;
        public HousebreakController(BhavCopiesContext context)
        {
            _context = context;
        }


        //[HttpGet]
        //public ActionResult<List<HousebreakInfo>> ScanHousebreaks()
        //{
        //    List<string> distinctStockNames = getAllStockNames();
        //    List<HousebreakInfo> housebreaksList = new List<HousebreakInfo>();
        //    foreach (string ticker in distinctStockNames)
        //    {
        //        List<HousebreakInfo> housebreakList = GetHousebreaksOfTicker(ticker);
        //        if (Convert.ToDateTime(housebreakList[housebreakList.Count - 1].DayOfBreak.Date) == DateTime.Today.Date)
        //        {
        //            housebreaksList.Add(housebreakList[housebreakList.Count - 1]);
        //            break;
        //        }
        //    }
        //    return housebreaksList;
        //}

        [HttpGet]
        public ActionResult<List<HousebreakInfo>> ScanHousebreaksOfSingleTicker(string Ticker)
        {
            if(Ticker==null)
            {
                List<string> distinctStockNames = getAllStockNames();
                List<HousebreakInfo> housebreaksList = new List<HousebreakInfo>();
                int counter = 0;
                foreach (string ticker in distinctStockNames)
                {
                    List<HousebreakInfo> housebreakList = GetHousebreaksOfTicker(ticker);
                    if (counter == 10)
                        break;
                    else
                    {
                        counter++;
                    }
                        
                    if (housebreakList.Count > 0)
                    {
                        DateTime breakDate = Convert.ToDateTime(housebreakList[housebreakList.Count - 1].DayOfBreak.Date);
                        if((breakDate.Day == DateTime.Today.Date.Day) &&
                            (breakDate.Month == DateTime.Today.Date.Month) &&
                            (breakDate.Year == DateTime.Today.Date.Year))
                        {
                            housebreaksList.Add(housebreakList[housebreakList.Count - 1]);
                            break;
                        }
                    }
                    

                    
                }
                return housebreaksList;
            }
            else
                return GetHousebreaksOfTicker(Ticker);
        }

        private List<string> getAllStockNames()
        {
            var bcs = (from b in _context.BhavCopies
                      select b.Ticker).Distinct();
            return bcs.ToList();
        }
        private List<HousebreakInfo> GetHousebreaksOfTicker(string ticker)
        {
            List<BhavCopies> bhavCopiesList;//= _context.BhavCopies.Where(c => c.Ticker == Ticker).OrderBy(c => c.Date.ToList();
            var bcs = from b in _context.BhavCopies
                      where b.Ticker == ticker
                      orderby b.Date ascending
                      select b;
            bhavCopiesList = bcs.ToList();
            List<HousebreakInfo> housebreaksList = HousebreakScanner.ScanForHousebreaks(bhavCopiesList);
            bhavCopiesList = bcs.ToList();
            return housebreaksList;
        }
    }
}