using Framework.Driver;
using Framework.LogicSteps;
using Framework.Pages;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    [Parallelizable]
    public class TestSearch : BaseTest
    {
        LoginPage loginPage;
        CurrentJournalPage current;
        AdvansedSearchPage advansedSearchPage;
        ResultSearchPage resultPage;
        MyFavoritePage myFavoritePage;
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Driver = DriverManager.DriverInstanse.Driver;
            Driver.Navigate().GoToUrl("http://journals.lww.com/plasreconsurg/pages/default.aspx");
            Driver = DriverManager.DriverInstanse.Driver;
            loginPage = new LoginPage();
            current = new CurrentJournalPage();
            advansedSearchPage = new AdvansedSearchPage();
            resultPage = new ResultSearchPage();
            myFavoritePage = new MyFavoritePage();
            SearchSteps.Login(current, loginPage, "Ksenvov", "Qwerty12345");
        }

        [Test]
        public void TestCountResultsOnCurrentPage()
        {
            SearchSteps.FindByKeyWord(current, advansedSearchPage, "blood");
            SearchSteps.CalculateResults(resultPage);
            Assert.IsTrue(SearchSteps.resultsOnCurrentPage > 20);
            Assert.IsTrue(SearchSteps.allResults > 100);
        }

        [Test]
        public void TestCountResultsOnNextPage()
        {
            SearchSteps.FindByKeyWord(current, advansedSearchPage, "blood");
            SearchSteps.CalculateResults(resultPage);
            SearchSteps.GoToNextPage(resultPage);
            Assert.IsTrue(SearchSteps.resultsOnCurrentPage > 20);
        }

        [Test]
        public void TestFindByTitle()
        {
            string titleExample = "Blood Supply and Skeletal Muscle Infarction";
            SearchSteps.FindBy(current, advansedSearchPage, titleExample);
            Assert.IsTrue(SearchSteps.IsExistTitle(resultPage, titleExample));

        }

        [Test]
        public void TestSaveSearch()
        {
            string titleExample = "Blood Supply and Skeletal Muscle Infarction";
            SearchSteps.FindBy(current, advansedSearchPage, titleExample);
            SearchSteps.SaveSearch(resultPage, "new");
            SearchSteps.GoToMyFavorites(resultPage);
            string result = SearchSteps.GetSearchKeyWords(myFavoritePage, resultPage, "new");
            Assert.IsTrue(result.Contains(titleExample));
        }

        [Test]
        public void TestOpenSearch()
        {
            string titleExample = "Blood Supply and Skeletal Muscle Infarction";
            SearchSteps.GoToMyFavorites(resultPage);
            string result = SearchSteps.GetSearchKeyWords(myFavoritePage, resultPage, "new");
            Assert.IsTrue(result.Contains(titleExample));
        }

        [TearDown]
        public void AfterTest()
        {
           // DriverManager.DriverInstanse.Quit();
        }
    }
}
