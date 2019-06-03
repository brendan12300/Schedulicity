using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Schedulicity.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver driver;

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
            driver.Navigate().GoToUrl("http://www.way2automation.com/protractor-angularjs-practice-website.html");
        }

        public RegistrationPage GoToRegistration()
        {
            registration.Click();
            return new RegistrationPage(driver);

        }
    }
}