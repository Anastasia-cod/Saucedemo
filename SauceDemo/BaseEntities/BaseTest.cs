using System;
using Allure.Commons;
using Core;
using Core.Utilities.Configuration;
using NUnit.Allure.Core;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Page;
using SauceDemo.Steps;

namespace SauceDemo.BaseEntities
{
    [AllureNUnit]
    public class BaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected static IWebDriver? Driver;
        protected WaitService? WaitService;
        protected NavigationStep NavigationStep;

        private AllureLifecycle _allure;

        public LoginPage LoginPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            _logger.Trace("Message level Trace");
            _logger.Debug("Message level Debug");
            _logger.Info("Message level Info");
            _logger.Warn("Message level Warn");
            _logger.Error("Message level Error");
            _logger.Fatal("Message level Fatal");

            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);

            NavigationStep = new NavigationStep(Driver);
            LoginPage = new LoginPage(Driver);
            LoginPage.OpenPage();

            //Initialization allure
            _allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            //Verify that test is failed
            if(TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                //Create screenshot
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                //Attach screenshot
                _allure.AddAttachment(name: "Screenshot", type: "image/png", screenshotBytes);
            }

            Driver?.Quit();
            Driver.Dispose();
        }
    }
}

