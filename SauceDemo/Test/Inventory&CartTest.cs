using System;
using SauceDemo.Builder;
using SauceDemo.Page;

namespace SauceDemo.Test
{
    public class Inventory_CartTest : BaseTest
    {
        public LoginPage LoginPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            LoginPage = new LoginPage();
            var standartuser = UserBuilder.StandartUser;

            LoginPage.SuccessfulLogin(standartuser);
        }

        [Test, Category("Positive")]
        public void AddingItemToCart_ViaInventoryPage()
        {
            //var
            var expectedAddedItem = "Sauce Labs Bolt T-Shirt";

            //Action
            var cartPage = new InventoryPage()
                .AddTShirtToCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo(expectedAddedItem));
        }

        [Test, Category("Positive")]
        public void AddingItemToCartAndRemovingItemFromCart_ViaInventoryPage()
        {
            //var
            var expectedAddedItem = "Sauce Labs Backpack";

            //Action
            var cartPage = new InventoryPage()
                .AddTShirtToCart()
                .AddBackPackToCart()
                .RemoveTShirtFromCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo(expectedAddedItem));
        }

        [Test, Category("Positive")]
        public void CheckSwitchingToItemInfoPageFromInventoryPage()
        {
            //var
            var expectedTitle = "Sauce Labs Backpack";

            //Action
            var itemInfoPage = new InventoryPage()
                .GoToItemInfoPage_ClickToBackpackLink();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(itemInfoPage.CheckBackPackItemLinkIsDisplayed(), Is.True);
                Assert.That(itemInfoPage.GetBackpackTitle, Is.EqualTo(expectedTitle));
            });
            
        }

        [Test, Category("Positive")]
        public void AddingItemToCart_ViaItemInfoPage()
        {
            //var
            var expectedAddedItem = "Sauce Labs Backpack";

            //Action
            var cartPage = new InventoryPage()
                .GoToItemInfoPage_ClickToBackpackLink()
                .AddBackpackToCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo(expectedAddedItem));
        }

        [Test, Category("Positive")]
        public void AddingItemToCartViaInventoryPage_AndRemovingItemFromCartViaItemInfoPage()
        {
            //var
            var expectedAddedItem = "Sauce Labs Bolt T-Shirt";

            //Action
            var cartPage = new InventoryPage()
                .AddTShirtToCart()
                .GoToItemInfoPage_ClickToBackpackLink()
                .AddBackpackToCart()
                .RemoveBackpackFromCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo(expectedAddedItem));
        }
    }
}

