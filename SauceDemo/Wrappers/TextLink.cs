﻿using System;
using OpenQA.Selenium;

namespace SauceDemo.Wrappers
{
    public class TextLink
    {

        private UIElement _uiElement;

        public TextLink(IWebDriver? driver, By @by)
        {
            _uiElement = new UIElement(driver, @by);
        }

        public void Click() => _uiElement.Click();

        public string Text => _uiElement.Text;

        public bool Displayed => _uiElement.Displayed;
    }
}

