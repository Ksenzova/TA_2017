using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Framework.Driver
{
    public class DriverManager
    {
        private static Dictionary<string, IWebDriver> listOfDrivers = new Dictionary<string, IWebDriver>();

        private DriversType type;
  
        public IWebDriver Driver
        {
            get
            {
                if (!listOfDrivers.ContainsKey(TestContext.CurrentContext.Test.ClassName))
                {
                    listOfDrivers.Add(TestContext.CurrentContext.Test.ClassName, BrowserFactory.InitBrowser(type));
                }
                IWebDriver result;
                listOfDrivers.TryGetValue(TestContext.CurrentContext.Test.ClassName, out result);
                return result;
            }

        }

        public static DriverManager DriverInstanse;

        private DriverManager(DriversType type)
        {
            this.type = type;
        }

        public static DriverManager SetDriver(DriversType type)
        {
            if (DriverInstanse == null)
            {
                DriverInstanse = new DriverManager(type);
            }
            return DriverInstanse;
        }

        public void Quit()
        {
            Driver.Quit();
            listOfDrivers.Remove(TestContext.CurrentContext.Test.ClassName);
        }
    }
}
