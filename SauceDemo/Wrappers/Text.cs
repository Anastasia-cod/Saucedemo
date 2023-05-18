using System;
using OpenQA.Selenium;

namespace SauceDemo.Wrappers
{
	public class Text : BaseElement
    {
        public Text(By locator) : base(locator)
        {
        }

        public Text(string locator) : base($"{locator}")
        {
        }
    }
}


