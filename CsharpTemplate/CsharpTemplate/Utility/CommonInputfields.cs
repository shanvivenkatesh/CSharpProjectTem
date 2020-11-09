using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.Utility
{
    public class CommonInputfields
    {
        private readonly Random Random = new Random();



        public string OrderRefference() => "Test" + Random.Next(0, 8700);
        public string AccountValue() => "Account" + Random.Next(0, 8700);
        public string AgentCode() => "Agent" + Random.Next(0, 8700);
        public string SubAccountValue() => "subAccount" + Random.Next(0, 8700);
        public string ProviderName() => "AXA Rosenberg";
        public string FundIdentifierValueIsin() => "IS987656" + Random.Next(0, 8700);
        public string FundIdentifierValueSedol() => "123" + Random.Next(0, 8700);
        public string SelectSettlementCcy() => "EUR";
        public string UnitsValue() => "100";
        public string CashValue() => "1000";
        public string CashCurrency() => "EUR";
        public string FundName() => "FundName" + Random.Next(0, 8700);
        public string FundIdentifierValueAPIR() => "A12" + Random.Next(0, 8700) + "AA";
        public string FundIdentifierTypeAPIR() => "APIR";
        public string FundIdentifierTypeSEDOL() => "SEDOL";
    }
}
