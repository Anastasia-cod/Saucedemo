using System;
using OpenQA.Selenium;

namespace SauceDemo.Wrappers
{
    public class Input : BaseElement
    {
        public Input(By locator) : base(locator)
        {
        }

        public Input(string locator) : base($"{locator}")
        {
        }

        public void FillIn(string message)
        {
            Browser.Driver.FindElement(Locator).SendKeys(message);
        }

        public void UpdateValue(string message)
        {
            Browser.Driver.FindElement(Locator).Clear();
            Browser.Driver.FindElement(Locator).SendKeys(message);
        }
    }
}
