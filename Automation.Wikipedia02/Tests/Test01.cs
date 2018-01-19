using Automation.Wikipedia01.Base;
using Automation.Wikipedia01.Pages;
using NUnit.Framework;

namespace Automation.Wikipedia01.Tests
{
    [TestFixture]
    [Parallelizable]
    class Test01 : BaseWebDriver
    {
        
        PrePage pp = new PrePage(testBrowser);
        MainPage mp = new MainPage(testBrowser);
        SearchResultPage srp = new SearchResultPage(testBrowser);
        EditPage ep = new EditPage(testBrowser);

        [Test]
        public void CheckPrePage()
        {
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
