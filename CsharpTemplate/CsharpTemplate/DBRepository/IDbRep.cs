using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.DBRepository
{
    public interface IDbRep
    {
        public List<string> GetRoutedFundProviderForgivenClient(string clientCode);
        public string GetFundProviderExistForGivenClient(string clientCode, string name);
    }
}
