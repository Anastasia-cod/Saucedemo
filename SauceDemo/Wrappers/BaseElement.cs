using System;
using Core.Selenium;
using OpenQA.Selenium;

namespace SauceDemo.Wrappers
{
    public class BaseElement
    {
        protected Browser Browser => Browser.Instance;
        protected By Locator { get; }

        public BaseElement(By locator)
        {
            Locator = locator;
        }

        public BaseElement(string locator)
        {
            Locator = By.Id(locator);
        }

        public void Click()
        {
            Browser.Driver.FindElement(Locator).Click();
        }

        public string GetText()
        {
            return Browser.Driver.FindElement(Locator).Text;
        }

        public bool CheckIsDisplayed()
        {
            return Browser.Driver.FindElement(Locator).Displayed;
        }
    }
}


