using CsharpTemplate.Framework.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.Framework.DriverObjectFactory
{
    public interface IDriverFactory
    {
        string Name { get; }



        IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration);



        dynamic SetCapabilities(WebBrowserConfiguration webBrowserConfiguration);
    }
}
