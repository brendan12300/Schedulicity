//-----------------------------------------------------------------------
// <copyright file="SchedulicityTests.cs" company="N/A">
//     Copyright (c) Brendan Blanchard All rights reserved.
// </copyright>
// <author>Brendan Blanchard</author>
//-----------------------------------------------------------------------

namespace Schedulicity
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Schedulicity.PageObjects;

    /// <summary>
    /// this class is the <see cref="SchedulicityTests"/> tests class.
    /// </summary>
    [TestClass]
    public class SchedulicityTests
    {
        /// <summary>
        /// web driver instance
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Sets up Chrome driver and maximizes the browser window for test
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);
        }

        /// <summary>
        /// Does the test for exercise 1.
        /// </summary>
        [TestMethod]
        public void RegSuccess()
        {
            HomePage home = new HomePage(this.driver);
            home.GoToPage();
            RegistrationPage reg = home.GoToRegistration();
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);
            reg.TestsRegisration(true);
            this.driver.Quit();
        }

        /// <summary>
        /// Does the test for exercise 2.
        /// </summary>
        [TestMethod]
        public void RegFail()
        {
            HomePage home = new HomePage(this.driver);
            home.GoToPage();
            RegistrationPage reg = home.GoToRegistration();
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);
            reg.TestsRegisration(false);
            this.driver.Quit();
        }

        /// <summary>
        /// Does the test for exercise 3.
        /// </summary>
        [DataTestMethod]
        public void DeleteAdmin()
        {
            HomePage home = new HomePage(this.driver);
            home.GoToPage();
            WebTablesPage webTables = home.GoToWebTables();
            this.driver.SwitchTo().Window(this.driver.WindowHandles[1]);
            webTables.FindAdminUserAndDeleteButton();
            DeletePopup deletePopup = webTables.DeleteAdmin();
            webTables = deletePopup.ClickOk();
            webTables.FindAdminUserAndDeleteButton();
            Assert.IsNull(webTables.AdminDeleteButton);
            this.driver.Quit();
        }
    }
}
