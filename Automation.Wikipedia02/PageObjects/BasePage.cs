using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automation.Wikipedia01.Pages
{
    public class BasePage
    {
        public static IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        public void OpenPage(string PageURL)
        {
            Driver.Navigate().GoToUrl(PageURL);
            string url = Driver.Url.ToString();
            Assertions.AssertIt(() => Assert.AreEqual(url, PageURL));
            Console.WriteLine("Opened page url: '" + PageURL + "' is correct.");
        }

        public void WaitUntilClickable(IWebElement element)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.ElementToBeClickable(element));
        }

        /*
        public IWebElement FindElementByXpath(string elementXPath)
        {
            IWebElement element = new WebDriverWait(Driver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.ElementExists(By.XPath(elementXPath)));
            return element;
        }
        */

        public void SelectDropdownItem(IWebElement element, string menuItemText)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
            new SelectElement(element).SelectByText(menuItemText);
            Console.WriteLine("Dropdown Item '" + menuItemText + "' is selected.");
        }

        public void SearchByInputTextIntoSearchField(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
            element.Submit();
            Console.WriteLine("Search with text '" + text + "' is done.");
        }
    }
}