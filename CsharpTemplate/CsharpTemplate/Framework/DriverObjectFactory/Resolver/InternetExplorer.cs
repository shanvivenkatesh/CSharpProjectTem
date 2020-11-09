using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CsharpTemplate.Framework.Configuration;

namespace CsharpTemplate.Framework.DriverObjectFactory.Resolver
{
    public class InternetExplorerResolver : IDriverFactory
    {
        public string Name { get { return "internet explorer"; } }



        public IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration)
        {
            var options = SetCapabilities(webBrowserConfiguration);



            IWebDriver driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            driver.Manage().Window.Maximize();
            return driver;
        }



        public dynamic SetCapabilities(WebBrowserConfiguration webBrowserConfiguration)
        {
            InternetExplorerOptions option = new InternetExplorerOptions();
            option.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            option.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
            return option;
        }
    }
}
