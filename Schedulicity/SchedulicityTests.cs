using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Schedulicity.PageObjects;


namespace Schedulicity
{
    [TestClass]
    public class SchedulicityTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        }

        [TestMethod]
        public void RegSuccess()
        {
            HomePage home = new HomePage(driver);
            home.GoToPage();
            home.GoToRegistration();
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
