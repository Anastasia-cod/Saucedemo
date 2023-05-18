using System;
using Core.Selenium;
using SauceDemo.Page;

namespace SauceDemo.Test
{
    public class BaseTest
    {
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

