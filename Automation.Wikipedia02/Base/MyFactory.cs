using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation.Wikipedia01.Base
{
    internal class MyFactory
    {
        internal static IWebDriver GetBrowserInstance()
        {
            return new ChromeDriver();

            //TODO: need add logic
            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            //driver = new EdgeDriver();
        }
    }
}