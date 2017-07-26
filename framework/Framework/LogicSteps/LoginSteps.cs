using Framework.Pages;

namespace Framework.LogicSteps
{
    public class LoginSteps
    {
        public static void Login(LoginPage page, string user, string password)
        {
            Logger.Info("Started login step");
            page.User.Clear();
            page.User.SendKeys(user);
            page.Password.Clear();
            page.Password.SendKeys(password);
            page.Submit.Click();
            Logger.Info("Ended login step");
        }
    }
}
