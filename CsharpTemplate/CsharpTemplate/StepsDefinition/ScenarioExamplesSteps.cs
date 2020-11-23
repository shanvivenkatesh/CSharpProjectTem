using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CsharpTemplate.StepsDefinition
{
    [Binidng]
    public class ScenarioExamplesSteps
    {

        private readonly ScenarioContext _context;
        private readonly OrderSummaryPage _summaryPage;
        private readonly OrderCardsHeaderPage _headerPage;
        private readonly OrderFilterPanel _orderFilterPanelPage;
        private readonly OrderCardsHeaderPage _orderCardsPage;



        public FilterOrderByOrderStatusSteps(ScenarioContext injectedContext, OrderCardsHeaderPage headerPage, OrderSummaryPage summarypage, OrderFilterPanel orderFilterPanel, OrderCardsHeaderPage orderCard)
        {
            _context = injectedContext;
            _summaryPage = summarypage;
            _headerPage = headerPage;
            _orderFilterPanelPage = orderFilterPanel;
            _orderCardsPage = orderCard;
        }



        [When(@"User select order (.*) in order status filter")]
        public void WhenUserSelectOrderSubmittedInOrderStatusFilter(string orderStatusOption)
        {
            _summaryPage.AccessFilter();
            _orderFilterPanelPage.SelectOrderStatus(orderStatusOption);
            _summaryPage.WaitForFilteredOrderCount();
        }



        [Then(@"user can see same (.*) in the summary page")]
        public void ThenUserCanSeeSameInTheSummaryPage(int number)
        {
            string[] orderStatus = _orderFilterPanelPage.GetOrderStatusText("orderStatus");
            foreach (var label in _orderCardsPage.GetOrderStatusOnOrderCardHeader())
            {
                Assert.That(orderStatus[number].ToUpper().Contains(label.Text));
            }
        }
    }
}