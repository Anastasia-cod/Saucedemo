using System;
using OpenQA.Selenium;

namespace SauceDemo.Wrappers
{
	public class CartLink : BaseElement
    {
        public CartLink(By locator) : base(locator)
        {
        }

        public CartLink(string locator) : base($"{locator}")
        {
        }
    }
}

