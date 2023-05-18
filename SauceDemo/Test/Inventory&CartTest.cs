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
        public void AddingItemToCart()
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
        public void AddingItemToCartAndRemovingItemFromCart()
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
    }
}

