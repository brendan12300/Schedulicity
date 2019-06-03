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
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);
        }

        [TestMethod]
        public void RegSuccess()
        {
            HomePage home = new HomePage(driver);
            home.GoToPage();
            RegistrationPage reg = home.GoToRegistration();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            reg.TestsRegisration(true);
            driver.Quit();
        }

        [TestMethod]
        public void RegFail()
        {
            HomePage home = new HomePage(driver);
            home.GoToPage();
            RegistrationPage reg = home.GoToRegistration();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            reg.TestsRegisration(false);
            driver.Quit();
        }

        [DataTestMethod]
        public void DeleteAdmin()
        {
            HomePage home = new HomePage(driver);
            home.GoToPage();
            WebTablesPage webTables = home.GoToWebTables();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            webTables.FindAdminUserAndDeleteButton();
            DeletePopup deletePopup = webTables.DeleteAdmin();
            webTables = deletePopup.ClickOk();
            webTables.FindAdminUserAndDeleteButton();
            Assert.IsNull(webTables.AdminDeleteButton);
            driver.Quit();
        }

       
    }
}
