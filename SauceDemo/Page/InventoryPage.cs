using System;
using System.Net;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Test;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class InventoryPage : BasePage
    {
        private static string endPoint = "inventory.html";

        TextLink inventoryItemLink = new TextLink(By.XPath("//div[@class='inventory_item_name']"));
        TextLink backpackLink = new TextLink(By.XPath("//div[text()='Sauce Labs Backpack']"));
        TextLink tShirtLink = new TextLink(By.XPath("//div[text()='Sauce Labs Bolt T-Shirt']"));
        Button addBackpackToCart = new Button("add-to-cart-sauce-labs-backpack");
        Button addTShirtToCart = new Button("add-to-cart-sauce-labs-bolt-t-shirt");
        Button removeBackPack = new Button("remove-sauce-labs-backpack");
        Button removeTShirt = new Button("remove-sauce-labs-bolt-t-shirt");

        public InventoryPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public InventoryPage(IWebDriver driver) : base(driver, false)
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

        public bool CheckInventoryItemLinkIsDisplayed()
        {
            return inventoryItemLink.CheckIsDisplayed();
        }

        public ItemInfoPage GoToItemInfoPage_ClickToBackpackLink()
        {
            backpackLink.Click();

            return new ItemInfoPage(Driver, true);
        }

        public string GetBackpackTitle()
        {
            return backpackLink.GetText();
        }

        public InventoryPage AddBackPackToCart()
        {
            addBackpackToCart.Click();

            return this;
        }

        public InventoryPage AddTShirtToCart()
        {
            addTShirtToCart.Click();

            return this;
        }

        public InventoryPage RemoveTShirtFromCart()
        {
            removeTShirt.Click();

            return this;
        }
    }
}

