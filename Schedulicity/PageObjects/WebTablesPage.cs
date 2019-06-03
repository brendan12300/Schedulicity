//-----------------------------------------------------------------------
// <copyright file="WebTablesPage.cs" company="N/A">
//     Copyright (c) Brendan Blanchard All rights reserved.
// </copyright>
// <author>Brendan Blanchard</author>
//-----------------------------------------------------------------------

namespace Schedulicity.PageObjects
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;

    /// <summary>
    /// this class is the <see cref="WebTablesPage"/> page object class.
    /// </summary>
    public class WebTablesPage
    {
        /// <summary>
        /// web driver instance
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebTablesPage"/> class.
        /// </summary>
        /// <param name="driver"> takes Selenium driver</param>
        public WebTablesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Gets or sets selector for <see cref="AdminDeleteButton"/> with initial value of null.
        /// </summary>
        public IWebElement AdminDeleteButton { get; set; } = null;

        /// <summary>
        /// Finds selectors for userElement admin and then sets the selector for the deletion button for the admin, if it can not find the admin user
        /// it sets the selector for the deletion button to null and that is used to assert in the test that the admin user was deleted. It dynamically 
        /// sets the selector based on what the value of the increment variable for the for loop is because it is the same value of 
        /// the row in the table it is in.
        /// </summary>
        public void FindAdminUserAndDeleteButton()
        {
            for (int i = 1; i < 7; i++)
            {
                var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("tbody .ng-scope:nth-of-type(1) .smart-table-data-cell:nth-of-type(11) [ng-class]")));
                IWebElement userElement = this.driver.FindElement(By.XPath("//tr[" + i.ToString() + "]/td[3]"));
                if (userElement.Text == "admin")
                {
                   this.AdminDeleteButton = this.driver.FindElement(By.CssSelector("tbody .ng-scope:nth-of-type(" + i.ToString() + ") .smart-table-data-cell:nth-of-type(11) [ng-class]"));
                    break;
                }
                else
                {
                    this.AdminDeleteButton = null;
                }
            }
        }

        /// <summary>
        /// Clicks the delete button for the admin user 
        /// </summary>
        /// <returns><see cref="DeletePopup"/> page object</returns>
        public DeletePopup DeleteAdmin()
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(this.AdminDeleteButton));
            this.AdminDeleteButton.Click();
            return new DeletePopup(this.driver);
        }
    }
}
