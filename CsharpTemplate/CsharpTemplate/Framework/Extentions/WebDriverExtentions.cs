using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CsharpTemplate.Framework.Extensions
{


/// <summary>
/// Extension class for webdriver
/// </summary>
public static class WebDriverExtensions
{



    private static int TimeOut = 59;
    /// <summary>
    /// Method will hold the process till page has been uploaded
    /// </summary>
    /// <param name="driver">driver you want to wait till page get load</param>
    public static void WaitToLoadPage(this IWebDriver driver)
    {
        IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));



        wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    }



    public static void WaitForAngularLoad(this IWebDriver driver)
    {
        IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));
        wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return (window.angular !== undefined) && (angular.element(document).injector() !== undefined) && (angular.element(document).injector().get('$http').pendingRequests.length === 0)"));
    }



    /// <summary>
    /// This function will wait for element to be exist and look for element every interval time
    /// </summary>
    /// <param name="driver">IWebDriver</param>
    /// <param name="locator">By</param>
    public static void WaitForElementToExist(this IWebDriver driver, By locator)
    {
        WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));
        waitForElement.IgnoreExceptionTypes(typeof(NoSuchElementException));
        waitForElement.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
        IWebElement ele = waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        Assert.IsTrue(ele.Displayed);
    }



    /// <summary>
    /// This function will wait for element to exist
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="element">IWebElement</param>
    public static void WaitForElementToExist(this IWebDriver driver, IWebElement element)
    {



        var waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));
        waitForElement.IgnoreExceptionTypes(typeof(NoSuchElementException));
        waitForElement.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
        var result = waitForElement.Until(ele => element.Displayed);
        Assert.IsTrue(result);
    }



    /// <summary>
    /// This method wait for element and click
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="element"></param>
    public static void WaitToElementExistandClick(this IWebDriver driver, IWebElement element)
    {



        var waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));
        var elementToClick = waitForElement.Until(ExpectedConditions.ElementToBeClickable(element));
        var builder = new Actions(driver);
        builder.MoveToElement(elementToClick).Click().Build().Perform();
    }



    public static void WaitToElementExistandClick(this IWebDriver driver, By locator)
    {
        var waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOut));
        IWebElement ele = waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        ele.Click();
    }
}
}
