using CsharpTemplate.Framework.Configuration;
using CsharpTemplate.Framework.Extensions;
using CsharpTemplate.Framework.PageObjectsFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly EnvironmentConfiguration environmentConfiguration;
        public LoginPage(IWebDriver driver, EnvironmentConfiguration environment) : base(driver) { environmentConfiguration = environment; }



        [FindsBy(How.Id, "Username")]
        private IWebElement UsernameTextBox { get; set; }



        [FindsBy(How.Id, "Password")]
        private IWebElement PasswordTextBox { get; set; }



        [FindsBy(How.XPath, "//button[@name='button']")]
        private IWebElement LoginButton { get; set; }



        public void LoginToOrdersUxPage()
        {
            Driver.Navigate().GoToUrl(environmentConfiguration.BaseURL);
            Driver.WaitToLoadPage();
            //Driver.WaitForElementToExist(UsernameTextBox);
            //EnterTextUsingJS(UsernameTextBox, environmentConfiguration.UserName);
            //EnterTextUsingJS(PasswordTextBox, environmentConfiguration.Password);
            //Driver.WaitToElementExistandClick(LoginButton);
            //Driver.WaitToLoadPage();
        }

        public string loginText()
        {
            return LoginButton.Text;
        }

        public string[] GetOrderStatusText(string status)
        {
            string[] orderStatusText = new string[10];
            Driver.WaitForElementToExist(SearchPanelBox);
            if (string.Equals(status, "orderStatus", System.StringComparison.CurrentCultureIgnoreCase))
            {
                for (int i = 0; i < 10; i++)
                {
                    orderStatusText[i] = Driver.FindElement(By.CssSelector("app-order-statuses :nth-child(" + (i + 2).ToString() + ") > label")).Text;
                }
            }



            return orderStatusText;
        }
    }
}
