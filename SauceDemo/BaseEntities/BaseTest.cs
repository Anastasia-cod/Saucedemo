using System;
using Core;
using Core.Utilities.Configuration;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Page;

namespace SauceDemo.BaseEntities
{
    [AllureNUnit]
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected static IWebDriver? Driver;
        protected WaitService? WaitService;

        public LoginPage LoginPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);

            LoginPage = new LoginPage(Driver);
            LoginPage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }
    }
}

