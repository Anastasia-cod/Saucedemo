using System;
using System.Xml.Linq;
using Core;
using OpenQA.Selenium;
using SauceDemo.Wrappers;
using SauceDemo.BaseEntities;

namespace SauceDemo.Page
{
    public class ItemInfoPage : BasePage
    {
        private static string END_POINT = "inventory-item.html?id=4";

        By BackpackLinkBy = By.XPath("//div[text()='Sauce Labs Backpack']");
        By ByAddBackpackToCartButtonBy = By.Id("add-to-cart-sauce-labs-backpack");
        By ByRemoveBackPackButtonBy = By.XPath("//button[text()='Remove']");

        public ItemInfoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public ItemInfoPage(IWebDriver driver) : base(driver, false)
        {
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(ByAddBackpackToCartButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckBackPackItemLinkIsDisplayed()
        {
            return Driver.FindElement(BackpackLinkBy).Displayed;
        }

        public string GetBackpackTitle()
        {
            return Driver.FindElement(BackpackLinkBy).Text;
        }

        public ItemInfoPage AddBackpackToCart()
        {
            Driver.FindElement(ByAddBackpackToCartButtonBy).Click();

            return this;
        }

        public ItemInfoPage RemoveBackpackFromCart()
        {
            Driver.FindElement(ByRemoveBackPackButtonBy).Click();

            return this;
        }
    }
}

