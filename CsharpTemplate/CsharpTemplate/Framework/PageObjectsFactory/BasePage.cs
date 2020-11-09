﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.Framework.PageObjectsFactory
{
    public abstract class BasePage
    {
        protected BasePage(IWebDriver webDriver)
        {
            this.Driver = webDriver;
            PageFactory.InitElements(Driver, this);
        }



        protected IWebDriver Driver { get; private set; }



        protected bool VerifyPageURL(string pageName)
        {
            return Driver.Url.Contains(pageName);
        }



        protected void EnterTextUsingJS(IWebElement TextBox, string inputString)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].value='" + inputString + "'", TextBox);
        }
    }
}
