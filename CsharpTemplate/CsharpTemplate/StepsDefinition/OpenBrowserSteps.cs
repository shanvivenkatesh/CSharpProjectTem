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
        private readonly ScenarioContext _context;

        public OpenBrowserSteps(LoginPage loginPage, ScenarioContext context)
        {
            _loginPage = loginPage;
            _context = context;
        }
        [Given(@"Open Browser")]
        public void GivenOpenBrowser()
        {
          _loginPage.LoginToOrdersUxPage();
            var text = _loginPage.loginText();
            _context.TryAdd("name", text);
            _context.Get<string>("name");
            var orderRef = _context.Get<string>("orderReference");
            var accountValue = _context.Get<string>("accountValue");
            var agentCode = _context.Get<string>("agentCode");
            var providername = _context.Get<string>("providername");
            var fundIdentifierValue = _context.Get<string>("fundIdentifierValue");
        }

    }
}
