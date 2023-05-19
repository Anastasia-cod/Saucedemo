using System;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public abstract class BasePage
    {
        protected static int waitForPageLoadingTime = 60;
        [ThreadStatic] protected IWebDriver Driver;

        TextLink shoppingCartLink = new TextLink(By.ClassName("shopping_cart_link"));

        protected abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = Browser.Instance.Driver;

            if(openPageByUrl)
            {
                OpenPage();
            }

            WaitForOpen();
        }

        protected void WaitForOpen()
        {
            var secondsCount = 0;
            var isPageOpenedIndicator = IsPageOpened();

            while (!isPageOpenedIndicator && secondsCount < waitForPageLoadingTime)
            {
                Thread.Sleep(1000);
                secondsCount++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if(!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }

        public CartPage GoToCartPage_ClickShoppingCartLink()
        {
            shoppingCartLink.Click();

            return new CartPage(Driver, true);
        }
    }
}