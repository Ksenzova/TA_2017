using Framework.Driver;
using OpenQA.Selenium;

namespace Framework.Pages
{
    /// <summary>
    /// Describe Article main elements of article page
    /// </summary>
    public class ArticlePage : BasePage
    {
        private By addToFavoriteButtonsXpath = By.XPath("//section[contains(@id,'ArticleTools')]//*[text()='Add to My Favorites']");

        public Element AddToFavoriteButtons;
        public ArticlePage()
        {
            Driver = DriverManager.DriverInstanse.Driver;
            AddToFavoriteButtons = new Element(Driver, addToFavoriteButtonsXpath);
        }
    }
}