using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CsharpTemplate.Framework.Configuration;

namespace CsharpTemplate.Framework.DriverObjectFactory.Resolver
{
    public class FirefoxResolver : IDriverFactory
    {
        public string Name { get { return "firefox"; } }



        public IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration)
        {
            dynamic option = SetCapabilities(webBrowserConfiguration);
            IWebDriver driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), option);
            driver.Manage().Window.Maximize();
            return driver;
        }



        public dynamic SetCapabilities(WebBrowserConfiguration webBrowserConfiguration)
        {
            FirefoxOptions option = new FirefoxOptions();
            option.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
            return option;
        }
    }
}