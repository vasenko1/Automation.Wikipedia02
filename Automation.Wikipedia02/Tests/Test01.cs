using Automation.Wikipedia01.Base;
using Automation.Wikipedia01.Pages;
using NUnit.Framework;

namespace Automation.Wikipedia01.Tests
{
    [TestFixture]
    [Parallelizable]
    class Test01 : BaseWebDriver
    {
        HomePage pp;
        MainPage mp;
        SearchResultPage srp;
        EditPage ep;

        [Test]
        public void CheckWikiStartPage()
        {
            pp = new HomePage(driver);
            mp = new MainPage(driver);
            srp = new SearchResultPage(driver);
            ep = new EditPage(driver);
            pp.RunTest();
        }

        [Test]
        public void SearchAndEditFlow()
        {
            mp.RunTest();
            srp.ClickEditTab();
            ep.RunTest();
        }
    }
}
