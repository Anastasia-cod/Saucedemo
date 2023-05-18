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

