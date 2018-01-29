using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace Automation.Wikipedia02.Pages
{
    class SpecialPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "firstHeading")]
        private IWebElement _headerID;

        public SpecialPage(IWebDriver driver) : base(driver)
        {
        }



        public void CheckingSpecialPageHeader(string validText)
        {
            string headerText = _headerID.Text;
            if (headerText == validText)
            {
                Assertions.AssertIt(() => Assert.AreEqual(headerText, validText));
                Console.WriteLine("Article page header (" + headerText + ") is correct.");
            }
            else if (headerText == "Search results")
            {
                Assertions.AssertIt(() => Assert.AreEqual(headerText, validText));
                Console.WriteLine("Article for text '" + headerText + "' is not opened.");
            }
            else
                Console.WriteLine("Unexpected behavior: Search for '" + validText + "'. Displayed text '" + headerText + "'.");


        }
    }
}