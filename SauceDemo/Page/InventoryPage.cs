using System;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class InventoryPage : BasePage
    {
        TextLink shoppingCartLink = new TextLink(By.ClassName("shopping_cart_link"));
        TextLink inventoryItemLink = new TextLink(By.XPath("//div[@class='inventory_item_name']"));
        TextLink backpackLink = new TextLink(By.XPath("//div[text()='Sauce Labs Backpack']"));
        TextLink tShirtLink = new TextLink(By.XPath("//div[text()='Sauce Labs Bolt T-Shirt']"));
        Button addBackpackToCart = new Button("add-to-cart-sauce-labs-backpack");
        Button addTShirtToCart = new Button("add-to-cart-sauce-labs-bolt-t-shirt");
        Button removeBackPack = new Button("remove-sauce-labs-backpack");
        Button removeTShirt = new Button("remove-sauce-labs-bolt-t-shirt");

        public bool CheckInventoryItemLinkIsDisplayed()
        {
            return inventoryItemLink.CheckIsDisplayed();
        }

        public CartPage GoToCartPage_ClickShoppingCartLink()
        {
            shoppingCartLink.Click();

            return new CartPage();
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

