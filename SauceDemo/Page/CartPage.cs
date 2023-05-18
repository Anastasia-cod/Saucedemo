using System;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CartPage : BasePage
    {
        Button remove = new Button("remove-sauce-labs-backpack");
        Button continueShopping = new Button("continue-shopping");
        Button checkout = new Button("checkout");
        TextLink firstAddedItemLink = new TextLink(By.ClassName("inventory_item_name"));

        public string GetTitleFirstAddedItem()
        {
            return firstAddedItemLink.GetText();
        }

        public CartPage ClickRemove()
        {
            remove.Click();

            return this;
        }

        public InventoryPage ReturnToInventoryShoppingPage()
        {
            continueShopping.Click();

            return new InventoryPage();
        }

        public CheckoutStepOnePage GoToCheckoutStepOnePage_ClickCheckoutButton()
        {
            checkout.Click();

            return new CheckoutStepOnePage();
        }

        public CartPage GoToCheckoutPage_WhenCartIsEmpty()
        {
            checkout.Click();

            return this;
        }
    }
}

