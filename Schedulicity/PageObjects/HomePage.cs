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
        public IWebElement registration;

        [FindsBy(How = How.CssSelector, Using = "li:nth-child(6) h2")]
        public IWebElement webTables;

        public void GoToPage()
        {
            // url not loading with Selenium unless I use https in the front of the url.
            driver.Navigate().GoToUrl("http://www.way2automation.com/protractor-angularjs-practice-website.html"); 
        }

        public RegistrationPage GoToRegistration()
        {
            registration.Click();
            driver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/registeration/#/login");
            return new RegistrationPage(driver);
            
        }
    }
}