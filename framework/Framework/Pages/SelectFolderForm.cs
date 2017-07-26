using Framework.Driver;
using OpenQA.Selenium;

namespace Framework.Pages
{
    /// <summary>
    /// Describe select folder form
    /// </summary>
    public class SelectFolderForm : BasePage
    {
        private By existingFolderRadioButtonXpath = By.XPath("//input[contains(@id,'ExistingCollection')]");
        private By existingFoldersXpath = By.XPath("//select[contains(@id,'ExistingCollection')]//option");
        private By newFolderRadioButtonXpath = By.XPath("//input[contains(@id,'NewCollection')]");
        private By newFolderNameXpath = By.XPath("//input[contains(@id,'CollectionName')]");
        private By submitButtonXpath = By.XPath("//input[contains(@value,'Add Item')]");
        private By goToMyCollectionButtonXpath = By.XPath("//input[contains(@value,'My Favorites')]");
        private By chooseAnotherNameMessageXpath = By.XPath("//*[contains(text(),'choose another name')]");

        public Element ExistingFolderButton;
        public Element ExistingFoldersBox;
        public Element NewFolderButton;
        public Element NewFolderBox;
        public Element SubmitButton;
        public Element GoToMyFavoriteButton;

        public SelectFolderForm()
        {
            Driver = DriverManager.DriverInstanse.Driver;
            ExistingFolderButton = new Element(Driver, existingFolderRadioButtonXpath);
            ExistingFoldersBox = new Element(Driver, existingFoldersXpath);
            NewFolderButton = new Element(Driver,newFolderRadioButtonXpath);
            NewFolderBox = new Element(Driver, newFolderNameXpath);
            SubmitButton = new Element(Driver, submitButtonXpath);
            GoToMyFavoriteButton = new Element(Driver, goToMyCollectionButtonXpath);
        }       
    }
}