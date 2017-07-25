using Framework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace Framework.Pages
{
    /// <summary>
    /// Describe page with user's folders
    /// </summary>
    public class MyFavoritePage : BasePage
    { 
        private By deleteButtonXpath = By.XPath("//*[contains(@id,'DeleteMyCollection') and contains(text(),'Delete')]");
        private By confirmDeleteButtonXpath = By.XPath("//input[contains(@type,'submit') and contains(@value,'Delete')]");

        public Element DeleteButton;
        public Element ConfirmDeleteButton;
        public Element Folder;
        public Element Article;
        public Element Search;
        public MyFavoritePage()
        {
            Driver = DriverManager.DriverInstanse.Driver;
            DeleteButton = new Element(Driver, deleteButtonXpath);
            ConfirmDeleteButton = new Element(Driver, confirmDeleteButtonXpath);
        }

        public bool IsRightFolder(string folderName)
        {
            folderName = folderName.Trim(' ');
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Time"])));
            string s = string.Concat("//td//*[text()='", folderName, "']");
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Concat("//td//*[text()='", folderName, "']")))).Click();
            return Driver.FindElement(By.XPath(string.Concat("//td//*[text()='", folderName, "']"))).Displayed;
            //By folderXpath = By.XPath(string.Concat("//td//a[text()='", folderName, "']"));
            //Folder = new Element(Driver, folderXpath);
            //Folder.FindElement().Click();
            //return Folder.Displayed;
        }
        public bool IsExistArticle(string article)
        {
            By articleXpath = By.XPath(string.Concat("//*[contains(@title,'", article, "')]"));
            Article = new Element(Driver, articleXpath);         
            return Article.Displayed;
        }

        public void GoToSearch(string searchName)
        {
            By searchXpath = By.XPath(string.Concat("//*[contains(@id,'MySearch')and contains(text(),'", searchName, "')]"));
            Search = new Element(Driver, searchXpath);
            Search.Click();
        }
    }
}
