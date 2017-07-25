using Framework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    /// <summary>
    /// Describe main elements of advansed serarch page
    /// </summary>
    public class AdvansedSearchPage :BasePage
    {
        private By enterKeyWordsBoxXpath = By.XPath("//input[contains(@value,'Keywords')]");
        private By submitSearchButtonXpath = By.XPath("//button[contains(@id,'Search')]");
        private By boxToEnterTitleXpath = By.XPath("//*[contains(@id,'advancedSearch')]//input[contains(@id,'keywords') and contains(@id,'2')]");
        private By searchButtonStartXpath = By.XPath("//input[contains(@type,'submit') and contains(@value,'Search')]");

        public Element SearchBox;
        public Element Submit;
        public Element BoxToEnteTitle;
        public Element SearchButton;

        public AdvansedSearchPage()
        {
            Driver = DriverManager.DriverInstanse.Driver;
            SearchBox = new Element(Driver, enterKeyWordsBoxXpath);
            Submit = new Element(Driver, submitSearchButtonXpath);
            BoxToEnteTitle = new Element(Driver, boxToEnterTitleXpath);
            SearchButton = new Element(Driver, searchButtonStartXpath);

        }
    }
}
