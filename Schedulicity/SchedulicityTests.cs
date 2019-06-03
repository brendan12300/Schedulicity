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
           
            HomePage home = new HomePage(driver);
            home.GoToPage();
            RegistrationPage reg = home.GoToRegistration();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            reg.Login(true);
            driver.Quit();
        }

        [TestMethod]
        public void RegFail()
        {
            HomePage home = new HomePage(driver);
            home.GoToPage();
            RegistrationPage reg = home.GoToRegistration();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            reg.Login(false);
            driver.Quit();
        }

       
    }
}
