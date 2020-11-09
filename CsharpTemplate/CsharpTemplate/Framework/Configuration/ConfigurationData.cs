using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.Framework.Configuration
{
    public class WebBrowserConfiguration
    {
        public string Browsertype { get; set; }
        public double Timeout { get; set; }
        public bool HeadlessMode { get; set; }
        public string BrowserName { get; set; }
        public string Platform { get; set; }
        public string RemoteUri { get; set; }
    }



    public class EnvironmentConfiguration
    {
        public string BaseURL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TestResultFolder { get; set; }
        public string ConnectionString { get; set; }
    }



    public class AzureSearchConfiguration
    {
        public string ServiceName { get; set; }
        public string IndexName { get; set; }
        public string ApiKey { get; set; }
    }



    public class InternalApiConfiguration
    {
        public string TokenUri { get; set; }
        public string BaseUri { get; set; }
        public string ClientName { get; set; }
        public string ClientSecret { get; set; }
    }
}