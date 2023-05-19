using System;
using SauceDemo.Builder;
using SauceDemo.Page;

namespace SauceDemo.Test
{
    public class Inventory_CartTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            var standartuser = UserBuilder.StandartUser;

            LoginPage.SuccessfulLogin(standartuser);
        }

        [Test, Category("Positive")]
        public void AddingItemToCart_ViaInventoryPage()
        {
            //Action
            var cartPage = InventoryPage
                .AddTShirtToCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo("Sauce Labs Bolt T-Shirt"));
        }

        [Test, Category("Positive")]
        public void AddingItemToCartAndRemovingItemFromCart_ViaInventoryPage()
        {
            //Action
            var cartPage = InventoryPage
                .AddTShirtToCart()
                .AddBackPackToCart()
                .RemoveTShirtFromCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo("Sauce Labs Backpack"));
        }

        [Test, Category("Positive")]
        public void CheckSwitchingToItemInfoPageFromInventoryPage()
        {
            //Action
            var itemInfoPage = InventoryPage
                .GoToItemInfoPage_ClickToBackpackLink();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(itemInfoPage.CheckBackPackItemLinkIsDisplayed(), Is.True);
                Assert.That(itemInfoPage.GetBackpackTitle, Is.EqualTo("Sauce Labs Backpack"));
            });
            
        }

        [Test, Category("Positive")]
        public void AddingItemToCart_ViaItemInfoPage()
        {
            //Action
            var cartPage = InventoryPage
                .GoToItemInfoPage_ClickToBackpackLink()
                .AddBackpackToCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo("Sauce Labs Backpack"));
        }

        [Test, Category("Positive")]
        public void AddingItemToCartViaInventoryPage_AndRemovingItemFromCartViaItemInfoPage()
        {
            //Action
            var cartPage = InventoryPage
                .AddTShirtToCart()
                .GoToItemInfoPage_ClickToBackpackLink()
                .AddBackpackToCart()
                .RemoveBackpackFromCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo("Sauce Labs Bolt T-Shirt"));
        }
    }
}

