using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace Core.Selenium
{
    public class Browser
    {
        private static Browser instance = null;
        private IWebDriver driver;

        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }
                return instance;
            }
        }

        public IWebDriver Driver { get { return driver; } }

        private Browser()
        {
            //driver = new ChromeDriver();

            switch (TestContext.Parameters.Get("Browser").ToLower())
            {
                case "chrome":

                    if (bool.Parse(TestContext.Parameters.Get("Headless")!))
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");
                        driver = new ChromeDriver(options);
                    }
                    else
                    {
                        driver = new ChromeDriver();
                    }

                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ContextClickToElement(IWebElement element)
        {
            new Actions(driver)
              .MoveToElement(element)
              .ContextClick()
              .Build()
              .Perform();
        }

        public void ContextClickToElement(By by)
        {
            var element = driver.FindElement(by);
            ContextClickToElement(element);
        }

        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public object ExecuteScript(string script)
        {
            try
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript(script);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public void SwitchToFirstWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        public void SwitchToLastWindow()
        {
            var windows = driver.WindowHandles;

            if (windows.Count > 1)
            {
                driver.SwitchTo().Window(windows[windows.Count - 1]);
            }
        }

        public void CloseTab()
        {
            driver.Close();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            instance = null;
        }
    }
}


