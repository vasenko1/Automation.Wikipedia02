using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automation.Wikipedia02.Pages
{
    class HomePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "js-link-box-en")]
        private IWebElement _linkEngId;

        [FindsBy(How = How.XPath, Using = "id('js-link-box-ru')/strong[1]")]
        private IWebElement _linkRusId;

        [FindsBy(How = How.XPath, Using = "//div[@class='central-featured']/div/a/strong")]
        private IList<IWebElement> _langLinksTextXPath;

        [FindsBy(How = How.XPath, Using = "id('searchLanguage')")]
        private IWebElement _searchLangDDXpath;

        public HomePage(IWebDriver driver) : base(driver)
        {
        }


        public void RunTest()
        {
            SwitchToPageByUrl("https://www.wikipedia.org/", "");
            SelectDropdownItem(_searchLangDDXpath, "Suomi");
            CheckPrePageTitleIsCorrect();
            Check10LangLinkElements();
            CheckHomePageIsCorrect();
            ClickEnglishLink();
        }

        private void CheckPrePageTitleIsCorrect()
        {
            string elementText = Driver.Title;
            Assertions.AssertIt(() => Assert.AreEqual(elementText, "Wikipedia"));

            Console.WriteLine("Page Title '" + elementText + "' is correct.");
        }

        private void Check10LangLinkElements()
        {
            const int number = 10;

            IList<IWebElement> allElements = _langLinksTextXPath;
            IList<String> value = new List<String>();

            foreach (IWebElement element in allElements) {
                value.Add(element.Text);
                Console.WriteLine("AA" + element.Text + " - OK!");
            }

            Assertions.AssertIt(() => Assert.AreEqual(value.Count, number));
            Console.WriteLine(number + " language link elements are presented.");
        }

        private void CheckHomePageIsCorrect()
        {
            string elementText = _linkRusId.Text;
            Assertions.AssertIt(() => Assert.AreEqual(elementText, "Русский"));

            Console.WriteLine("PrePage is fully checked.");
        }

        private void ClickEnglishLink()
        {
            _linkEngId.Click();
        }
    }
}
