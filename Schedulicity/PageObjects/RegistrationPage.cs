using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace Schedulicity.PageObjects
{
    public class RegistrationPage
    {
        private readonly IWebDriver driver;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#username")]
        private IWebElement usernameTextbox;


        [FindsBy(How = How.CssSelector, Using = "#formly_1_input_username_0")]
        private IWebElement usernameTextbox2;

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement passwordTextbox;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        private IWebElement loginButton;

        [FindsBy(How = How.CssSelector, Using = "h1")]
        private IWebElement loginSuccessText;

        [FindsBy(How = How.CssSelector, Using = ".alert-danger")]
        private  IWebElement loginFailText;

        public void Login(bool login)
        {
            string userName = "angular";
            string password = "password";
            string badPassword = "password1";
            string successMeassage = "Home";
            string failMessage = "Username or password is incorrect";
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(usernameTextbox));
            usernameTextbox.SendKeys(userName);
            usernameTextbox2.SendKeys(userName);
            if (login == true)
            {
                passwordTextbox.SendKeys(password);
            }
            else
            {
                passwordTextbox.SendKeys(badPassword);

            }
            loginButton.Click();
            if (login == true)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(loginSuccessText));
                Assert.AreEqual(successMeassage, loginSuccessText.Text);

            }
            else
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(loginFailText));
                Assert.AreEqual(failMessage, loginFailText.Text);
            }
        }
    }
}
