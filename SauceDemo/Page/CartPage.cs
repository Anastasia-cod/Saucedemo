using System;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CartPage
    {
        Button remove = new Button("remove-sauce-labs-backpack");
        Button continueShopping = new Button("continue-shopping");
        Button checkout = new Button("checkout");

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

        public CheckoutPage GoToCheckoutPage_WhenCartHasItems()
        {
            checkout.Click();

            return new CheckoutPage();
        }

        public CartPage GoToCheckoutPage_WhenCartIsEmpty()
        {
            checkout.Click();

            return this;
        }
    }
}

