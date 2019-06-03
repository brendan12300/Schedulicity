//-----------------------------------------------------------------------
// <copyright file="DeletePopup.cs" company="N/A">
//     Copyright (c) Brendan Blanchard All rights reserved.
// </copyright>
// <author>Brendan Blanchard</author>
//-----------------------------------------------------------------------
namespace Schedulicity.PageObjects
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;
    using SeleniumExtras.WaitHelpers;

    /// <summary>
    /// this class is the <see cref="WebTablesPage"/> page object class.
    /// </summary>
    public class DeletePopup
    {
        /// <summary>
        /// web driver instance
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePopup"/> class.
        /// </summary>
        /// <param name="driver"> takes Selenium driver</param>
        public DeletePopup(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Gets or sets selector for <see cref="OkButton"/>.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement OkButton { get; set; }

        /// <summary>
        /// Clicks Ok on the deletion popup.
        /// </summary>
        /// <returns> <see cref="WebTablesPage"/> page object</returns>
        public WebTablesPage ClickOk()
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(this.OkButton));
            this.OkButton.Click();
            return new WebTablesPage(this.driver);
        }
    }
}
