using System;
using Core;
using Core.Utilities.Configuration;
using OpenQA.Selenium;
using SauceDemo.Page;
using SauceDemo.Wrappers;

namespace SauceDemo.BaseEntities
{
    public abstract class BasePage
    {
        protected static int waitForPageLoadingTime = 60;
        protected IWebDriver Driver;
        protected WaitService WaitService;

        By ShoppingCartLinkBy = By.ClassName("shopping_cart_link");

        public abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            WaitService = new WaitService(Driver);

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        public CartPage GoToCartPage_ClickShoppingCartLink()
        {
            Driver.FindElement(ShoppingCartLinkBy).Click();

            return new CartPage(Driver, true);
        }
    }
}