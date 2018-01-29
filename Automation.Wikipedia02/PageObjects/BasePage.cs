using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automation.Wikipedia01.Pages
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SwitchToPageByUrl(string PageURL, string title)
        {
            Driver.Navigate().GoToUrl(PageURL);

            new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.TitleContains(title));

            Console.WriteLine("Switching to page url: '" + PageURL + "' correctly.");
        }

        public void WaitUntilClickable(IWebElement element, int timeout)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public IWebElement FindElementByXpath(string elementXPath)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.ElementExists(By.XPath(elementXPath)));
        }

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