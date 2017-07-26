using Framework.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;

namespace Tests
{
    [TestFixture]
    public class BaseTest
    {
        public string URL = "http://journals.lww.com";
        public string User;
        public string Password;
        public IWebDriver Driver;

        [SetUp]
        public virtual void SetUp()
        {
            DriversType type = (DriversType)Enum.Parse(typeof(DriversType), ConfigurationManager.AppSettings["Browser"]);
            DriverManager.SetDriver(type);
            
        }
    }
}