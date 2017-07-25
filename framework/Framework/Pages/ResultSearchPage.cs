using Framework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    public class ResultSearchPage :BasePage
    {
        public WebDriverWait Wait;
        private By articlesSearchXpath = By.XPath("//*[contains(@class,'articles')]//*[contains(text(),'Favorites')]");
        private By countResultXpath = By.XPath("//*[contains(@class,'resultCount')]");
        private By toNextPAge = By.XPath("//*[contains(@id,'nextLink')]");
        private By titlsOfSearchedElements = By.XPath("//*[contains(@class,'searchContent')]//header//*[@title]");
        private By buttonToSaveSearch = By.XPath("//*[contains(@class,'savedSearchClass')]//input[contains(@value,'Save Search')]");
        public By linkToGoToMySearhes = By.XPath("//*[contains(@class,'mySaved')]");
        private By search1Xpath = By.XPath("//*[contains(@id,'userKeyWords')]");
        private By userActionsXpath = By.XPath("//*[contains(@id,'UserAccount')]");
        private By goToMyFavoritesXpath = By.XPath(" //*[contains(@id,'AccountActions')]//*[contains(@id,'MyFavorites') and contains(text(),'Favorites')]");



        public SaveSearchForm SaveForm;
        public ResultSearchPage()
        {
            Driver = DriverManager.DriverInstanse.Driver;
            SaveForm = new SaveSearchForm();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(45));
        }

        public int CountArticles()
        {
            Wait.Until(ExpectedConditions.ElementExists(articlesSearchXpath));
            return Driver.FindElements(articlesSearchXpath).Count;
        }

        public int CountAllResults()
        {
            Wait.Until(ExpectedConditions.ElementExists(countResultXpath));
            return int.Parse(Driver.FindElement(countResultXpath).Text.Split(' ')[0]);
        }

        public void GoToNextPage()
        {
            Wait.Until(ExpectedConditions.ElementExists(toNextPAge)).Click();
        }

        public bool IsTitleExist(string title)
        {
            Wait.Until(ExpectedConditions.ElementExists(titlsOfSearchedElements));
            bool IsExist = false;
            foreach (var elem in Driver.FindElements(titlsOfSearchedElements))
            {
                if (elem.Text == title)
                {
                    IsExist = true;
                    break;
                }
            }
            return IsExist;
        }

        public void SaveSearch()
        {
            Wait.Until(ExpectedConditions.ElementExists(buttonToSaveSearch)).Click();
        }

        public void ChooseUserActions()
        {
            Wait.Until(ExpectedConditions.ElementExists(userActionsXpath)).Click();          
        }
        public void GoToMyFavorites()
        {
            Wait.Until(ExpectedConditions.ElementExists(goToMyFavoritesXpath)).Click();
        }
        
        public string GetSearchKeyWords()
        {
            Wait.Until(ExpectedConditions.ElementExists(search1Xpath));
            return Driver.FindElement(search1Xpath).Text;
        }   
    }
}
