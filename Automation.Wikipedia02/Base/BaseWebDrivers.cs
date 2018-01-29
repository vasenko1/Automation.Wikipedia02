using NUnit.Framework;
using OpenQA.Selenium;

namespace Automation.Wikipedia01.Base
{

    [TestFixture]
    [Parallelizable]
    class BaseWebDriver
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //reporter
        }

        [SetUp]
        public void SetUp()
        {
            driver = MyFactory.GetBrowserInstance();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //reporter -> generate report
        }
    }
}
