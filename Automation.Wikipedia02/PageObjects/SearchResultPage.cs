using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Wikipedia01.Pages
{
    class SearchResultPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "ca-edit")]
        private IWebElement _editTabId;

        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickEditTab()
        {
            WaitUntilClickable(_editTabId, 10);
            _editTabId.Click();
            Console.WriteLine("Edit tab is clicked.");
        }
    }
}