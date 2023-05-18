using System;
using OpenQA.Selenium;

namespace SauceDemo.Wrappers
{
    public class TextLink : BaseElement
    {
        public TextLink(By locator) : base(locator)
        {
        }

        public TextLink(string locator) : base($"{locator}")
        {
        }
    }
}

