using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using CsharpTemplate.Framework.Configuration;

namespace CsharpTemplate.Framework.DriverObjectFactory.Resolver
{
    public class RemoteDriverResolver : IDriverFactory
    {
        /// <summary>
        /// Gets the name of the supported browser.
        /// </summary>
        /// <value>The name of the supported browser.</value>
        public string Name { get { return "remote"; } }



        public IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration)
        {
            IWebDriver driver = new RemoteWebDriver(new Uri(webBrowserConfiguration.RemoteUri), SetCapabilities(webBrowserConfiguration));
            driver.Manage().Window.Maximize();
            return driver;
        }



        public dynamic SetCapabilities(WebBrowserConfiguration webBrowserConfiguration)
        {
            DriverOptions option = DriverFactory.DriverFactoryList.Find(item => item.Name == webBrowserConfiguration.BrowserName).SetCapabilities(webBrowserConfiguration);
            option.AddAdditionalCapability("enableVNC", true);
            option.AddAdditionalCapability("enableVideo", false);



            return option;
        }
    }
}