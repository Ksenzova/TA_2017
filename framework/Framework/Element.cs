using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Framework
{
    public class Element 
    {
        private IWebElement elementInstance;
        public  IWebElement ElementInstsnce
        {
            get
            {
                if (elementInstance==null)
                {                   
                    elementInstance = wait.Until(ExpectedConditions.ElementExists(by));
                }
                return elementInstance;
            }
        }

        WebDriverWait wait;
        private IWebDriver driver;
        By by;

        public Element(IWebDriver driver, By by)
        {
            this.by = by;
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Time"])));
        }


        public bool Displayed
        {
            get
            {
                return ElementInstsnce.Displayed;
            }
        }

        public bool Enabled
        {
            get
            {
                return ElementInstsnce.Enabled;
            }
        }

        public Point Location
        {
            get
            {
                return ElementInstsnce.Location;
            }
        }

        public bool Selected
        {
            get
            {
                return ElementInstsnce.Selected;
            }
        }

        public Size Size
        {
            get
            {
                return ElementInstsnce.Size;
            }
        }

        public string TagName
        {
            get
            {
                return ElementInstsnce.TagName;
            }
        }

        public string Text
        {
            get
            {
                return ElementInstsnce.Text;
            }
        }

        public void Clear()
        {
            ElementInstsnce.Clear();
        }

        public void Click()
        {
            Logger.Info(string.Concat(by," Click"));
            ElementInstsnce.Click();
        }

        public IWebElement FindElement()
        {
            return ElementInstsnce.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements()
        {
            return ElementInstsnce.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return ElementInstsnce.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return ElementInstsnce.GetCssValue(propertyName);
        }

        public void SendKeys(string text)
        {
            Logger.Info(string.Concat(by, ":  SendKey", text));
            ElementInstsnce.SendKeys(text);
        }

        public void Submit()
        {
            Logger.Info(string.Concat(by, ":  Submit"));
            ElementInstsnce.Submit();
        }

    }
}
