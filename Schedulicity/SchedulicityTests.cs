using System;
using System.Threading;
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
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);
        }

        [TestMethod]
        public void RegSuccess()
        {
            string successMeassage = "You're logged in!!";
            HomePage home = new HomePage(driver);
            home.GoToPage();
            RegistrationPage reg = home.GoToRegistration();
            reg.Login();
            Assert.AreEqual(successMeassage, reg.loginSuccessText.Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
