using System;
using Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Page;

namespace SauceDemo.Test
{
    public class BaseTest
    {
        [ThreadStatic] protected static IWebDriver? Driver;

        public LoginPage LoginPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            Browser.Instance.NavigateToUrl("https://www.saucedemo.com");
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}

