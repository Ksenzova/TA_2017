using Framework.Driver;
using OpenQA.Selenium;

namespace Framework.Pages
{
    /// <summary>
    /// Describe form to save searh
    /// </summary>
    public class SaveSearchForm : BasePage
    {
        private By searchNameBoxXpath = By.XPath("//input[contains(@type,'text') and contains(@id,'SaveSearch')]");
        private By saveSearchButtonXpath = By.XPath("//input[contains(@type,'submit') and contains(@value,'Search')]");
        private By closeWindowButtonXpath = By.XPath("//button[contains(@onclick,'close')]");

        public Element SearchNameBox;
        public Element SaveSearchButton;
        public Element CloseWindowButton;
        public SaveSearchForm()
        {
            Driver = DriverManager.DriverInstanse.Driver;
            SearchNameBox = new Element(Driver, searchNameBoxXpath);
            SaveSearchButton = new Element(Driver, saveSearchButtonXpath);
            CloseWindowButton = new Element(Driver, closeWindowButtonXpath);
        }
    }
}
