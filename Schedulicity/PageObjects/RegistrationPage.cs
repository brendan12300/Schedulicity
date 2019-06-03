//-----------------------------------------------------------------------
// <copyright file="RegistrationPage.cs" company="N/A">
//     Copyright (c) Brendan Blanchard All rights reserved.
// </copyright>
// <author>Brendan Blanchard</author>
//-----------------------------------------------------------------------

namespace Schedulicity.PageObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;
    using SeleniumExtras.WaitHelpers;

    /// <summary>
    /// this class is the <see cref="RegistrationPage"/> object class it uses the page factory library
    /// </summary>
    public class RegistrationPage
    {
        /// <summary>
        /// web driver instance
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationPage"/> class.
        /// </summary>
        /// <param name="driver"> takes Selenium driver</param>
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Gets or sets selector for <see cref="UsernameTextbox"/>.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "#username")]
        public IWebElement UsernameTextbox { get; set; }

        /// <summary>
        /// Gets or sets selector for <see cref="UsernameTextbox2"/>.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "#formly_1_input_username_0")]
        public IWebElement UsernameTextbox2 { get; set; }

        /// <summary>
        /// Gets or sets selector for <see cref="PasswordTextbox"/>.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "#password")]
        public IWebElement PasswordTextbox { get; set; }

        /// <summary>
        /// Gets or sets selector for <see cref="LoginButton"/>.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".btn")]
        public IWebElement LoginButton { get; set; }

        /// <summary>
        /// Gets or sets selector for <see cref="LoginSuccessText"/>
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "h1")]
        public IWebElement LoginSuccessText { get; set; }

        /// <summary>
        /// Gets or sets selector for <see cref="LoginFailText"/>
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".alert-danger")]
        public IWebElement LoginFailText { get; set; }

        /// <summary>
        /// Tests the registration of a user
        /// </summary>
        /// <param name="success">bool to test success or fail scenarios</param>
        public void TestsRegisration(bool success)
        {
            string userName = "angular";
            string password = "password";
            string badPassword = "password1";
            string successMeassage = "Home";
            string failMessage = "Username or password is incorrect";
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(this.UsernameTextbox));
            this.UsernameTextbox.SendKeys(userName);
            this.UsernameTextbox2.SendKeys(userName);
            if (success == true)
            {
                this.PasswordTextbox.SendKeys(password);
            }
            else
            {
                this.PasswordTextbox.SendKeys(badPassword);
            }

            this.LoginButton.Click();

            if (success == true)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(this.LoginSuccessText));
                Assert.AreEqual(successMeassage, this.LoginSuccessText.Text);
            }
            else
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(this.LoginFailText));
                Assert.AreEqual(failMessage, this.LoginFailText.Text);
            }
        }
    }
}
