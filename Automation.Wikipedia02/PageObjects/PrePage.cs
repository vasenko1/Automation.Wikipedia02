using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Wikipedia01.Pages
{
    class PrePage : BasePage
    {
        private string pageURL = "https://www.wikipedia.org/";

        [FindsBy(How = How.Id, Using = "js-link-box-en")]
        private IWebElement _linkEngId;

        [FindsBy(How = How.XPath, Using = "id('js-link-box-ru')/strong[1]")]
        private IWebElement _linkRusId;

        [FindsBy(How = How.XPath, Using = "//div[@class='central-featured']/div/a/strong")]
        private IWebElement _LangLinksTextXPath;

        [FindsBy(How = How.XPath, Using = "id('searchLanguage')")]
        private IWebElement _SearchLangDDXpath;

        public PrePage(IWebDriver driver) : base(driver)
        {
        }


        public void RunTest()
        {
            OpenPage(pageURL);
            SelectDropdownItem(_SearchLangDDXpath, "Suomi");
            CheckPrePageTitleIsCorrect();
            Check10LangLinkElements();
            CheckPrePageIsCorrect();
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
            int i = 0;

            IList<IWebElement> allElements = Driver.FindElements(By.XPath("//div[@class='central-featured']/div/a/strong"));
            String[] elementsText = new String[allElements.Count];
            foreach (IWebElement element in allElements)
            {
                elementsText[i++] = element.Text;
            }

            for (i = 0; i < elementsText.Length; i++)
            {
                Console.WriteLine("     "+ (i + 1) + ") " + elementsText[i] + " - OK!");
            }
            Assertions.AssertIt(() => Assert.AreEqual(elementsText.Length, number));

            Console.WriteLine(number + " language link elements are presented.");
        }

        private void CheckPrePageIsCorrect()
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
