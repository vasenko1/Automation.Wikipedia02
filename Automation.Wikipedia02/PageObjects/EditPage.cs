using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation.Wikipedia01.Pages
{
    class EditPage : BasePage
    {
        private string editPageUrl = "https://en.wikipedia.org/w/index.php?title=Dropdown&action=edit&editintro=Template:Disambig_editintro";

        [FindsBy(How = How.XPath, Using = "id('editpage-specialchars')/select")]
        private IWebElement _dropDownMenuXpath;

        public EditPage(IWebDriver driver) : base(driver)
        {
        }

        public void RunTest()
        {
            CheckIsEditPageOpened();
            SelectDropdownItems("IPA (English)");
        }

        private void SelectDropdownItems(string text)
        {
            SelectDropdownItem(_dropDownMenuXpath, text);
        }

        private void CheckIsEditPageOpened()
        {
            string elementText = Driver.Url.ToString();
            Assertions.AssertIt(() => Assert.AreEqual(elementText, editPageUrl));
            Console.WriteLine("Opened Edit page URL is correct.");
        }
    }
}
