using System;
using Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Page;

namespace SauceDemo.Test
{
    public class BaseTest
    {
        public static readonly string? baseUrl = TestContext.Parameters.Get("URL");

        [ThreadStatic] protected static IWebDriver? Driver;

        public LoginPage LoginPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            Browser.Instance.NavigateToUrl(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}

