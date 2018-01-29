using System;
using Automation.Wikipedia02;
using Automation.Wikipedia02.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Wikipedia02.PageObjects
{
    class ArticlePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "firstHeading")]
        private IWebElement _headerID;

        [FindsBy(How = How.Id, Using = "ca-edit")]
        private IWebElement _editTabId;

        public ArticlePage(IWebDriver driver) : base(driver)
        {
        }

        private void IsSpecialPageOpened(string text)
        {
            string headerText = _headerID.Text;
            if (headerText == "Search results")
            {
                throw new Exception("Article for text '" + text + "' is not opened.");
            }
        }

        public void CheckingArticlePageHeader(string validText)
        {
            string headerText = _headerID.Text;
            IsSpecialPageOpened(validText);
            Assertions.AssertIt(() => Assert.AreEqual(headerText, validText));
            Console.WriteLine("Article page header (" + headerText + ") is correct.");
            
        }

        public void ClickEditTab()
        {
            WaitUntilClickable(_editTabId, 10);
            _editTabId.Click();
            Console.WriteLine("Edit tab is clicked.");
        }
    }
}
