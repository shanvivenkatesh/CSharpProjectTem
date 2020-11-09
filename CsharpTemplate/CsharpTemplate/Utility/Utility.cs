using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.Utility
{
    public static class Utility
    {
        public static string GetTimeStampUniqueNumber()
        {
            return DateTime.Now.ToString("HHmmss");
        }



        public static string GetDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }



        public static string GetDateAndMonth()
        {
            return DateTime.Now.ToString("dd/MM");
        }



        public static string GetDateTime()
        {
            return DateTime.UtcNow.ToString("dd/MM/yyyy, HH:mm");
        }



        public static string GetDateAndAddFourDays()
        {
            return DateTime.Now.AddDays(4).ToString("dd/MM/yyyy");
        }



        public static string GetExpectedTradeDate()
        {
            return DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");
        }



        public static string GetExpectedCashSettlementDate()
        {
            return DateTime.Now.AddDays(18).ToString("dd/MM/yyyy");
        }



        public static string GetExpectedCashSettlementDateInRepair()
        {
            return DateTime.Now.AddDays(14).ToString("dd/MM/yyyy");
        }
    }
}
