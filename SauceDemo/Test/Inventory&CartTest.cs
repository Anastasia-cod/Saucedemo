using System;
using Core.Models;
using SauceDemo.Page;
using SauceDemo.BaseEntities;
using Core.Models.Builder;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;
using SauceDemo.Steps;

namespace SauceDemo.Test
{
    public class Inventory_CartTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            NavigationStep.NavigateToLoginPage();
            NavigationStep.StandartUserLogin();
        }

        [Test(Description = "Adding item to Cart via Inventory page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Inventory test")]
        [AllureIssue("Issue - addind item to Cart ")]
        [AllureTms("Inventory - 1.1")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with valid credentials can add any item(s) to Cart via Inventory page")]
        public void AddingItemToCart_ViaInventoryPage()
        {
            //Action
            var cartPage = new InventoryPage(Driver, true)
                .AddTShirtToCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo("Sauce Labs Bolt T-Shirt"));
        }

        [Test(Description = "Adding item to Cart and removing item from Cart via Inventory page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Inventory test")]
        [AllureIssue("Issue - addind and removing item via Inventory page")]
        [AllureTms("Inventory - 1.2")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with valid credentials can add any item(s) to Cart and remove added items from Cart via Inventory page")]
        public void AddingItemToCartAndRemovingItemFromCart_ViaInventoryPage()
        {
            //Action
            var cartPage = new InventoryPage(Driver, true)
                .AddTShirtToCart()
                .AddBackPackToCart()
                .RemoveTShirtFromCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo("Sauce Labs Backpack"));
        }

        [Test(Description = "Switching from Inventory to Inventory Info page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Inventory test")]
        [AllureIssue("Issue - ability to go to Inventory info page from Inventory page")]
        [AllureTms("Inventory - 1.3")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with valid credentials can go to the Inventory info page from Inventory page clicking by title of the item")]
        public void CheckSwitchingToItemInfoPageFromInventoryPage()
        {
            //Action
            var itemInfoPage = new InventoryPage(Driver, true)
                .GoToItemInfoPage_ClickToBackpackLink();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(itemInfoPage.CheckBackPackItemLinkIsDisplayed(), Is.True);
                Assert.That(itemInfoPage.GetBackpackTitle, Is.EqualTo("Sauce Labs Backpack"));
            });

        }

        [Test(Description = "Adding item to Cart via Inventory Info page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Inventory test")]
        [AllureIssue("Issue - ability to add item to Cart via Inventory Info page")]
        [AllureTms("Inventory - 1.4")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with valid credentials can go to the Inventory info page from Inventory page clicking by title of the item and add the item to Cart")]
        public void AddingItemToCart_ViaItemInfoPage()
        {
            //Action
            var cartPage = new InventoryPage(Driver, true)
                .GoToItemInfoPage_ClickToBackpackLink()
                .AddBackpackToCart()
                .GoToCartPage_ClickShoppingCartLink();

            //Assert
            Assert.That(cartPage.GetTitleFirstAddedItem(), Is.EqualTo("Sauce Labs Backpack"));
        }

        [Test(Description = "Adding item to Cart via Inventory page and removing item from cart via Inventory Info page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Inventory test")]
        [AllureIssue("Issue - ability to add item to Cart via Inventory page and remove from the Inventory Info page")]
        [AllureTms("Inventory - 1.5")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with valid credentials can add item to cart from Inventory page, go to the Inventory info page clicking by title of the item and remove the item from Cart")]
        public void AddingItemToCartViaInventoryPage_AndRemovingItemFromCartViaItemInfoPage()
        {
            //Action
            var cartPage = new InventoryPage(Driver, true)
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

