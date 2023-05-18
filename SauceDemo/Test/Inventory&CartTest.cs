using System;
using Bogus;
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
            UserBuilder builder = new UserBuilder();

            var standartUser = builder
                .SetName(TestContext.Parameters.Get("StandartUserName"))
                .SetPassword(TestContext.Parameters.Get("StandartUserPassword"))
                .SetFirstName("Ivan")
                .SetLastName("Ivanov")
                .SetZipOrPostalCode("12345")
                .Build();

            LoginPage.SuccessfulLogin(standartUser);
        }

        [Test, Category("Positive")]
        public void AddingItemToCart_ViaInventoryPage()
        {
            //Action
            var cartPage = new InventoryPage()
                .AddTShirtToCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo("Sauce Labs Bolt T-Shirt"));
        }

        [Test, Category("Positive")]
        public void AddingItemToCartAndRemovingItemFromCart_ViaInventoryPage()
        {
            //Action
            var cartPage = new InventoryPage()
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
            var itemInfoPage = new InventoryPage()
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
            var cartPage = new InventoryPage()
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
            var cartPage = new InventoryPage()
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

