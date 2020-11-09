using CsharpTemplate.Framework.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsharpTemplate.Framework.DriverObjectFactory.Resolver
{
    public class ChromeResolver : IDriverFactory
    {
        public string Name { get { return "chrome"; } }



        public IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration)
        {
            dynamic option = SetCapabilities(webBrowserConfiguration);



            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService(Directory.GetCurrentDirectory());
            IWebDriver driver = new ChromeDriver(driverService, option);
            return driver;
        }



        public dynamic SetCapabilities(WebBrowserConfiguration webBrowserConfiguration)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
            if (webBrowserConfiguration.HeadlessMode)
                option.AddArguments("headless");
            return option;
        }
    }
}
