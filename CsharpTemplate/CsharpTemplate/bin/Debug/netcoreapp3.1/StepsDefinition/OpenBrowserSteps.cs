using CsharpTemplate.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CsharpTemplate.StepsDefinition
{
    [Binding]
    public class OpenBrowserSteps
    {
        private readonly LoginPage _loginPage;

        public OpenBrowserSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }
        [Given(@"Open Browser")]
        public void GivenOpenBrowser()
        {
            _loginPage.LoginToOrdersUxPage();
        }

    }
}
