using Framework.Driver;
using OpenQA.Selenium;

namespace Framework.Pages
{
    /// <summary>
    /// Describe main elements of page witch contains list of journals
    /// </summary>
    public class ListOfJournalsPage : BasePage
    {
        private By journalXpath = By.XPath("//*[contains(@id,'ListContainer')]//a[1]");

        public Element FirstJournal;
        public ListOfJournalsPage()
        {            
            Driver = DriverManager.DriverInstanse.Driver;
            FirstJournal = new Element(Driver, journalXpath);
        }
    }
}