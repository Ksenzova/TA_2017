using Framework.Driver;
using OpenQA.Selenium;

namespace Framework.Pages
{
    /// <summary>
    /// Discribe current journal page
    /// </summary>
    public class CurrentJournalPage : BasePage
    {
        private By favoriteButtonsXpath = By.XPath("//div[contains(@id,'List')]//*[contains(text(),'Favorites')]");
        private By articleXpath = By.XPath("//*[contains(@id,'ListContainer')]//header//*[@title]");
        private By loginButtonXpath = By.XPath("//*[contains(@class,'header-right')]//*[contains(text(),'Login')]");
        private By advanceSearchXpath = By.XPath("//*[contains(@id,'AdvanceSearch')]");

        public Element FavoriteButton;
        public Element Articles;
        public Element LoginButton;
        public Element AdvansedSearchLink;
        public CurrentJournalPage()
        { 
            Driver = DriverManager.DriverInstanse.Driver;
            FavoriteButton = new Element(Driver, favoriteButtonsXpath);
            Articles = new Element(Driver,articleXpath);
            LoginButton = new Element(Driver, loginButtonXpath);
            AdvansedSearchLink = new Element(Driver, advanceSearchXpath);
        }
    }
}
