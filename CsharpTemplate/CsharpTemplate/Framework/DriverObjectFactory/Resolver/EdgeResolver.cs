using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CsharpTemplate.Framework.Configuration;

namespace CsharpTemplate.Framework.DriverObjectFactory.Resolver
{
    public class EdgeResolver : IDriverFactory
    {
        public string Name { get { return "edge"; } }
        public IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration)
        {
            dynamic options = SetCapabilities(webBrowserConfiguration);



            EdgeDriverService service = EdgeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            System.Environment.SetEnvironmentVariable("webdriver.edge.driver", Assembly.GetExecutingAssembly().Location);
            RemoteWebDriver driver = new EdgeDriver(service, options);
            driver.Manage().Window.Maximize();
            return driver;
        }



        public dynamic SetCapabilities(WebBrowserConfiguration webBrowserConfiguration)
        {
            EdgeOptions option = new EdgeOptions();
            option.PageLoadStrategy = PageLoadStrategy.Eager;
            return option;
        }
    }
}