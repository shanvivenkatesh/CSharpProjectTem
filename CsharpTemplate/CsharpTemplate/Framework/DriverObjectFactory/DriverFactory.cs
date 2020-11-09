using CsharpTemplate.Framework.DriverObjectFactory.Resolver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using CsharpTemplate.Framework.Configuration;

namespace CsharpTemplate.Framework.DriverObjectFactory
    
{
    public class DriverFactory
    {
        private string Btype = string.Empty;
        public WebBrowserConfiguration WebBrowserConfiguration;



        public static List<IDriverFactory> DriverFactoryList = new List<IDriverFactory>
        {
                new ChromeResolver(),
                new FirefoxResolver(),
                new InternetExplorerResolver(),
                new EdgeResolver(),
                new RemoteDriverResolver()
        };



        public DriverFactory(WebBrowserConfiguration webBrowserConfiguration)
        {
            WebBrowserConfiguration = webBrowserConfiguration;
            Btype = webBrowserConfiguration.Browsertype;
        }



        public IWebDriver Create()
        {
            IWebDriver driver;
            driver = DriverFactoryList.Find(item => item.Name == Btype).Resolve(WebBrowserConfiguration);
            return driver;
        }
    }
}
