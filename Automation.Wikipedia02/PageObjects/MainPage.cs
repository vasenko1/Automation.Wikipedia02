using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automation.Wikipedia01.Pages
{
    class MainPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "searchInput")]
        private IWebElement _searchFieldID;

        [FindsBy(How = How.Id, Using = "firstHeading")]
        private IWebElement _headerID;

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void RunTest()
        {
            SwitchToMainPageByUrl();
            SearchByInputTextIntoSearchField(_searchFieldID, "Dropdown");
            CheckMainPageHeaderIsCorrect("Dropdown");
            Console.WriteLine("MainPage is fully checked.");
        }

        public void SwitchToMainPageByUrl()
        {
            SwitchToPageByUrl("https://en.wikipedia.org/wiki/Main_Page", "");

            new WebDriverWait(Driver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.TitleContains("DAASDAS"));

            Console.WriteLine("Switching to MainPage correctly.");
        }

        private void CheckMainPageHeaderIsCorrect(string text)
        {
            string elementText = _headerID.Text;
            Assertions.AssertIt(() => Assert.AreEqual(elementText, text));
            Console.WriteLine("Main page header (" + elementText + ") is correct.");
        }
    }
}
