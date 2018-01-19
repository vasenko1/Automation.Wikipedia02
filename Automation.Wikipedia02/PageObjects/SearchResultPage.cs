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
            try
            {
                _editTabId.Click();
                Console.WriteLine("Edit tab is clicked.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}