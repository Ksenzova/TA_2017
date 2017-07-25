using Framework.Pages;

namespace Framework.LogicSteps
{
    public class SearchSteps
    {
        public static int resultsOnCurrentPage;
        public static int allResults;
        public static void Login(CurrentJournalPage page, LoginPage loginPage, string user, string password)
        {
            page.LoginButton.Click();
            loginPage = new LoginPage();
            LoginSteps.Login(loginPage, user, password);
        }

        public static  void FindByKeyWord(CurrentJournalPage current, AdvansedSearchPage advansed,string keyWord)
        {
            current.AdvansedSearchLink.Click();
            advansed.SearchBox.SendKeys(keyWord);
            advansed.Submit.Click();
        }

        public static void CalculateResults(ResultSearchPage page)
        {
            resultsOnCurrentPage = page.CountArticles();
            allResults = page.CountAllResults();
        }

        public static void GoToNextPage(ResultSearchPage page)
        {
            page.GoToNextPage();
        }

        public static void FindBy(CurrentJournalPage current, AdvansedSearchPage page, string keyWords)
        {
            current.AdvansedSearchLink.Click();
            page.BoxToEnteTitle.SendKeys(keyWords);
            page.SearchButton.Click();
        }
        public static bool IsExistTitle(ResultSearchPage resultPage, string title)
        {
            return resultPage.IsTitleExist(title);
        }

        public static void SaveSearch(ResultSearchPage resultPage, string searchName)          
        {
            resultPage.SaveSearch();
            resultPage.SaveForm.SearchNameBox.SendKeys(searchName);
            resultPage.SaveForm.SaveSearchButton.Click();
            resultPage.SaveForm.CloseWindowButton.Click();          
        }

        public static void GoToMyFavorites(ResultSearchPage resultPage)
        {
            resultPage.ChooseUserActions();
            resultPage.GoToMyFavorites();
        }

        public static string GetSearchKeyWords(MyFavoritePage page, ResultSearchPage resultPage , string search)
        {
            page.IsRightFolder("Saved Searches");
            page.GoToSearch(search);
            return resultPage.GetSearchKeyWords();
        }
        
    }
}
