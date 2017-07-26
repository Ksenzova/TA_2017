using Framework.Driver;
using Framework.LogicSteps;
using Framework.Pages;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    [TestFixture]
    [Parallelizable]
    public class TestAddindToFavorits : BaseTest
    {
        LoginPage loginPage;
        ListOfJournalsPage listPage;
        CurrentJournalPage currentJournal;
        SelectFolderForm form;
        MyFavoritePage favoritePage;
        ArticlePage articlePage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Driver = DriverManager.DriverInstanse.Driver;
            Driver.Navigate().GoToUrl("http://journals.lww.com");
            Driver = DriverManager.DriverInstanse.Driver;
            loginPage = new LoginPage();
            string User = "Ksenvov";
            string Password = "Qwerty12345";
            LoginSteps.Login(loginPage, User, Password);

            listPage = new ListOfJournalsPage();
            currentJournal = new CurrentJournalPage();
            form = new SelectFolderForm();
            favoritePage = new MyFavoritePage();
            articlePage = new ArticlePage();
            AddingToFavoriteSteps.GoToFirstJournal(listPage);
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        [Test]
        public void TestAddingFromListToExistingFolder()
        {
            AddingToFavoriteSteps.ClickFavorite(currentJournal);
            string article = AddingToFavoriteSteps.FirstArticleTitle;
            AddingToFavoriteSteps.ToExistingFolder(form);
            string folderName = AddingToFavoriteSteps.FolderName;
            Assert.IsTrue(AddingToFavoriteSteps.IsAddedRight(favoritePage, folderName, article));
        }

        [Test]
        public void TestAddingFromListToNewFolder()
        {
            AddingToFavoriteSteps.ClickFavorite(currentJournal);
            string article = AddingToFavoriteSteps.FirstArticleTitle;
            string folderName = "folder8";
            AddingToFavoriteSteps.ToNewFolder(form, folderName);
            Assert.IsTrue(AddingToFavoriteSteps.IsAddedRight(favoritePage, folderName, article));
            AddingToFavoriteSteps.Delete(favoritePage);
        }

        [Test]
        public void TestAddingFromJournalToExistingFolder()
        {
            AddingToFavoriteSteps.GoToListOfArticles(currentJournal, articlePage);
            string article = AddingToFavoriteSteps.FirstArticleTitle;
            AddingToFavoriteSteps.ToExistingFolder(form);
            string folderName = AddingToFavoriteSteps.FolderName;
            Assert.IsTrue(AddingToFavoriteSteps.IsAddedRight(favoritePage, folderName, article));
        }

        [Test]
        public void TestAddingFromJournalToNewFolder()
        {
            AddingToFavoriteSteps.GoToListOfArticles(currentJournal, articlePage);
            string article = AddingToFavoriteSteps.FirstArticleTitle;
            string folderName = "folder8";
            AddingToFavoriteSteps.ToNewFolder(form, folderName);
            Assert.IsTrue(AddingToFavoriteSteps.IsAddedRight(favoritePage, folderName, article));
            AddingToFavoriteSteps.Delete(favoritePage);
        }

        [TearDown]
        public void AfterTest()
        {
     //       DriverManager.DriverInstanse.Quit();
        }
    }
}


