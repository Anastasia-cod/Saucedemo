using System;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public abstract class BasePage
    {
        public IWebDriver Driver { get; set; }
        TextLink shoppingCartLink = new TextLink(By.ClassName("shopping_cart_link"));


        public BasePage()
        {
            Driver = Browser.Instance.Driver;
        }

        public CartPage GoToCartPage_ClickShoppingCartLink()
        {
            shoppingCartLink.Click();

            return new CartPage();
        }
    }
}