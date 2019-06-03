//-----------------------------------------------------------------------
// <copyright file="HomePage.cs" company="N/A">
//     Copyright (c) Brendan Blanchard All rights reserved.
// </copyright>
// <author>Brendan Blanchard</author>
//-----------------------------------------------------------------------
namespace Schedulicity.PageObjects
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;

    /// <summary>
    /// this class is the <see cref="HomePage"/> page object class it uses the page factory library
    /// </summary>
    public class HomePage
    {
        /// <summary>
        /// web driver instance
        /// </summary>
        private readonly IWebDriver driver;      

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        /// <param name="driver"> takes Selenium driver</param>
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Gets or sets selector for registration page link.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "li:nth-child(1) h2")]
        public IWebElement Registration { get; set; }

        /// <summary>
        ///  Gets or sets selector for Web tables page link.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "li:nth-child(6) h2")]
        public IWebElement WebTables { get; set; }

        /// <summary>
        /// goes to <see cref=" HomePage"/>  of testing website.
        /// </summary>
        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://www.way2automation.com/protractor-angularjs-practice-website.html");
        }

        /// <summary>
        /// goes to <see cref="RegistrationPage"/>
        /// </summary>
        /// <returns><see cref="RegistrationPage"/></returns>
        public RegistrationPage GoToRegistration()
        {
            this.Registration.Click();
            return new RegistrationPage(this.driver);
        }

        /// <summary>
        /// goes to <see cref="WebTablesPage"/>
        /// </summary>
        /// <returns><see cref="WebTablesPage"/></returns>
        public WebTablesPage GoToWebTables()
        {
            this.WebTables.Click();
            return new WebTablesPage(this.driver);
        }
    }
}