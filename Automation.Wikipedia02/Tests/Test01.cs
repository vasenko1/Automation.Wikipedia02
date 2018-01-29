using Automation.Wikipedia02.Base;
using Automation.Wikipedia02.PageObjects;
using Automation.Wikipedia02.Pages;
using NUnit.Framework;

namespace Automation.Wikipedia02.Tests
{
    [TestFixture]
    [Parallelizable]
    class Test01 : BaseWebDriver
    {
        HomePage pp;
        MainPage mp;
        EditPage ep;
        ArticlePage ap;
        SpecialPage sp;

        [Test]
        public void CheckWikiStartPage()
        {
            pp = new HomePage(driver);
            pp.RunTest();
        }

        [Test]
        public void SearchAndEditFlow()
        {
            mp = new MainPage(driver);
            ap = new ArticlePage(driver);
            ep = new EditPage(driver);
            sp = new SpecialPage(driver);

            mp.SwitchToMainPageByUrl("Wikipedia");
            mp.DoSearchByText("Dropdown");
            ap.CheckingArticlePageHeader("Dropdown");
            ap.ClickEditTab();
            ep.RunTest();
        }
    }
}
