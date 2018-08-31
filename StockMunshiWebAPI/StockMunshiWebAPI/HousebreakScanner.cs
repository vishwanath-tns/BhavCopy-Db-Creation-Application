using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMunshiWebAPI.Models;

namespace StockMunshiWebAPI
{
    public class HousebreakInfo
    {
        public BhavCopies MotherCandle { get; set; }
        public int numberOfCandles { get; set; }

        public BhavCopies DayOfBreak { get; set; }
    }
    public static class HousebreakScanner
    {
        public static List<HousebreakInfo> ScanForHousebreaks(List<BhavCopies> bhavList)
        {
            List<HousebreakInfo> housebreaksHistory = new List<HousebreakInfo>();
            for(int i= bhavList.Count-30; i < bhavList.Count;i++)
            {
                BhavCopies motherCandle = bhavList[i - 1];
                BhavCopies insideDayCandle = bhavList[i];
                // Check for inside day
                if (IsInsideDay(motherCandle, insideDayCandle))
                {
                    // move till the mother candle high or low breaks
                    for(int j=i+1;j < bhavList.Count;j++)
                    {
                        if(IsCurrentCandleBreakOutOfMotherCandle(motherCandle, bhavList[j]))
                        {
                            HousebreakInfo hbInfo = new HousebreakInfo();
                            hbInfo.MotherCandle = motherCandle;
                            hbInfo.DayOfBreak = bhavList[j];
                            hbInfo.numberOfCandles = j - i;
                            housebreaksHistory.Add(hbInfo);
                            //Move the indices
                            i = j;
                            break;
                        }
                        else
                        {

                        }
                    }
                }
            }
            return housebreaksHistory;
        }

        public static bool IsCurrentCandleBreakOutOfMotherCandle(BhavCopies mc, BhavCopies currentCandle)
        {
            double mcHigh, mcLow;
            mcHigh = mc.High;
            mcLow = mc.Low;

            if (currentCandle.Close > mcHigh || currentCandle.Close < mcLow)
            {
                // Mother candle range is broken
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsInsideDay(BhavCopies mc,BhavCopies insideDay)
        {
            double mcHigh, mcLow;
            mcHigh = mc.High;
            mcLow = mc.Low;

            if(insideDay.High <= mcHigh && insideDay.Low >= mcLow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
