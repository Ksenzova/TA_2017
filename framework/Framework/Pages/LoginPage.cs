using Framework.Driver;
using OpenQA.Selenium;

namespace Framework.Pages
{
    /// <summary>
    /// Describe Maine elements ogf llogin form
    /// </summary>
    public class LoginPage : BasePage
    {
        private By userXpath = By.XPath("//input[contains(@name,'UserName')]");
        private By passwordXPath = By.XPath("//*[contains(@class,'login')]//input[contains(@name,'Password')]");
        private By submitButtonXpath = By.XPath("//input[contains(@name,'LoginButton')]");
        private By toValidInput = By.XPath("//*[contains(@id, 'Logout')]");
        private By toInvalidInput = By.XPath("//*[contains(@class,'error')]");

        public Element User;
        public Element Password;
        public Element Submit;
        public Element ToValidInput;
        public Element ToInvalidInput;

        public LoginPage()
        {
            Driver = DriverManager.DriverInstanse.Driver;
            User = new Element(Driver,userXpath);
            Password = new Element(Driver,passwordXPath);
            Submit = new Element(Driver,submitButtonXpath);           
        }

        /// <summary>
        /// To check valid log in
        /// </summary>
        /// <returns>is valid</returns>
        public bool IsValidInput()
        {
            ToValidInput = new Element(Driver,toValidInput);
            return ToValidInput.Displayed;
        }

        /// <summary>
        /// To ccheck in not valid log in
        /// </summary>
        /// <returns>is not valid</returns>
        public bool IsInvalidInput()
        {
            ToInvalidInput = new Element(Driver,toInvalidInput);
            return ToInvalidInput.Enabled;
        }        
    }
}
