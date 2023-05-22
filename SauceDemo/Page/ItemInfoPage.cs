using System;
using System.Net;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Test;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class ItemInfoPage : BasePage
    {
        private static string endPoint = "inventory-item.html?id=4";

        TextLink backpackLink = new TextLink(By.XPath("//div[text()='Sauce Labs Backpack']"));
        Button addBackpackToCart = new Button("add-to-cart-sauce-labs-backpack");
        Button removeBackPack = new Button(By.XPath("//button[text()='Remove']"));
        Button addToCart = new Button("add-to-cart-item-not-found");

        public ItemInfoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public ItemInfoPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Browser.Instance.NavigateToUrl(BaseTest.baseUrl + endPoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return addBackpackToCart.CheckIsDisplayed();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckBackPackItemLinkIsDisplayed()
        {
            return backpackLink.CheckIsDisplayed();
        }

        public string GetBackpackTitle()
        {
            return backpackLink.GetText();
        }

        public ItemInfoPage AddBackpackToCart()
        {
            addBackpackToCart.Click();

            return this;
        }

        public ItemInfoPage RemoveBackpackFromCart()
        {
            removeBackPack.Click();

            return this;
        }
    }
}

