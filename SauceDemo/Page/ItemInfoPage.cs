using System;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class ItemInfoPage : BasePage
    {
        TextLink backpackLink = new TextLink(By.XPath("//div[text()='Sauce Labs Backpack']"));
        Button addBackpackToCart = new Button("add-to-cart-sauce-labs-backpack");
        Button removeBackPack = new Button(By.XPath("//button[text()='Remove']"));

        public ItemInfoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public ItemInfoPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Browser.Instance.NavigateToUrl("https://www.saucedemo.com/inventory-item.html?id=4");
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

