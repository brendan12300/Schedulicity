using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Schedulicity.PageObjects
{
    public class RegistrationPage
    {
        private readonly IWebDriver driver;
        private string userName = "angular";
        private string password = "password";

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//input[@name='username']")]
        public readonly IWebElement usernameTextbox;

        [FindsBy(How = How.CssSelector, Using = "#formly_1_input_username_0")]
        public readonly IWebElement usernameTextbox2;

        [FindsBy(How = How.Id, Using = "password")]
        public readonly IWebElement passwordTextbox;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        public readonly IWebElement loginButton;

        [FindsBy(How = How.CssSelector, Using = "[class] div .ng-scope:nth-child(2)")]
        public readonly IWebElement loginSuccessText;

        public void Login()
        {
            usernameTextbox.SendKeys(userName);
            usernameTextbox2.SendKeys(userName);
            passwordTextbox.SendKeys(password);
            loginButton.Click();
        }

    }
}
