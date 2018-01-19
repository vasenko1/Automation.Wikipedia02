using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Automation.Wikipedia01.Base
{

    [TestFixture]
    [Parallelizable]
    class BaseWebDriver
    {
        private static IWebDriver chrome = new ChromeDriver();
        //public static IWebDriver firefox = new FirefoxDriver();
        //public static IWebDriver edge = new EdgeDriver();
        

        public static IWebDriver testBrowser = chrome;
        

        [OneTimeSetUp]
        public void Initialize()
        {
        }

        [OneTimeTearDown]
        public void Exit()
        {
            testBrowser.Close();
            testBrowser.Quit();
        }
    }
}
