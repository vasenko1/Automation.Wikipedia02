using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Wikipedia01.Pages
{
    class MainPage : BasePage
    {
        private string MainPageUrl = "https://en.wikipedia.org/wiki/Main_Page";

        [FindsBy(How = How.Id, Using = "searchInput")]
        private IWebElement _searchFieldID;

        [FindsBy(How = How.Id, Using = "firstHeading")]
        private IWebElement _headerID;

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void RunTest()
        {
            OpenPage(MainPageUrl);
            SearchByInputTextIntoSearchField(_searchFieldID, "Dropdown");
            CheckMainPageHeaderIsCorrect("Dropdown");
            Console.WriteLine("MainPage is fully checked.");
        }

        private void CheckMainPageHeaderIsCorrect(string text)
        {
            string elementText = _headerID.Text;
            Assertions.AssertIt(() => Assert.AreEqual(elementText, text));
            Console.WriteLine("Main page header (" + elementText + ") is correct.");
        }
    }
}
