using System;
using System.Xml.Linq;
using Core;
using OpenQA.Selenium;
using SauceDemo.Wrappers;
using SauceDemo.BaseEntities;

namespace SauceDemo.Page
{
    public class InventoryPage : BasePage
    {
        private static string END_POINT = "inventory.html";

        By InventoryItemLinkBy = By.XPath("//div[@class='inventory_item_name']");
        By BackpackLinkBy = By.XPath("//div[text()='Sauce Labs Backpack']");
        By TShirtLinkBy = By.XPath("//div[text()='Sauce Labs Bolt T-Shirt']");
        By AddBackpackToCartButtonBy = By.Id("add-to-cart-sauce-labs-backpack");
        By AddTShirtToCartButtonBy = By.Id("add-to-cart-sauce-labs-bolt-t-shirt");
        By RemoveBackPackButtonBy = By.Id("remove-sauce-labs-backpack");
        By RemoveTShirtButtonBy = By.Id("remove-sauce-labs-bolt-t-shirt");

        public InventoryPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public InventoryPage(IWebDriver driver) : base(driver, false)
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
                return Driver.FindElement(AddBackpackToCartButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckInventoryItemLinkIsDisplayed()
        {
            return Driver.FindElement(InventoryItemLinkBy).Displayed;
        }

        public ItemInfoPage GoToItemInfoPage_ClickToBackpackLink()
        {
            Driver.FindElement(BackpackLinkBy).Click();

            return new ItemInfoPage(Driver, true);
        }

        public string GetBackpackTitle()
        {
            return Driver.FindElement(BackpackLinkBy).Text;
        }

        public InventoryPage AddBackPackToCart()
        {
            Driver.FindElement(AddBackpackToCartButtonBy).Click();

            return this;
        }

        public InventoryPage AddTShirtToCart()
        {
            Driver.FindElement(AddTShirtToCartButtonBy).Click();

            return this;
        }

        public InventoryPage RemoveTShirtFromCart()
        {
            Driver.FindElement(RemoveTShirtButtonBy).Click();

            return this;
        }
    }
}

