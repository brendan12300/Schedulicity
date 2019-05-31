using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulicity.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(1) h2")]
        private IWebElement registration;

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(6) h2")]
        private IWebElement webTables;

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://www.way2automation.com/protractor-angularjs-practice-website.html");
        }

        public RegistrationPage GoToRegistration()
        {
            Thread.Sleep(1000);
            registration.Click();
            return new RegistrationPage(driver);
        }
    }
}