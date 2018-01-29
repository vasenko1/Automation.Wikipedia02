using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automation.Wikipedia02.Pages
{
    class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void SwitchToMainPageByUrl(string pageTitle)
        {
            SwitchToPageByUrl("https://en.wikipedia.org/wiki/Main_Page", pageTitle);

            new WebDriverWait(Driver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.TitleContains(pageTitle));

            Console.WriteLine("Switching to MainPage correctly.");
        }
    }
}
