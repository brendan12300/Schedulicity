using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [FindsBy(How = How.Id, Using = "username")]
        private readonly IWebElement usernameTextbox;

        [FindsBy(How = How.Id, Using = "formly_1_input_username_0")]
        private readonly IWebElement usernameTextbox2;

        [FindsBy(How = How.Id, Using = "password")]
        private readonly IWebElement passwordTextbox;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        private readonly IWebElement loginButton;

        public void Login()
        {
            usernameTextbox.SendKeys(userName);
            usernameTextbox2.SendKeys(userName);
            passwordTextbox.SendKeys(password);
            loginButton.Click();
        }

    }
}
