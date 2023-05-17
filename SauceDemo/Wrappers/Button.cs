using System;
using OpenQA.Selenium;

namespace SauceDemo.Wrappers
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator)
        {
        }

        public Button(string locator) : base($"{locator}")
        {
        }
    }
}