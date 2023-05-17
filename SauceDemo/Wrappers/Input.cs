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
    }
}
