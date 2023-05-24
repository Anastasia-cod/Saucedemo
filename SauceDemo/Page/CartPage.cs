using System;
using System.Xml.Linq;
using Core;
using Core.Utilities;
using OpenQA.Selenium;
using SauceDemo.BaseEntities;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CartPage : BasePage
    {
        private static string END_POINT = "cart.html";

        By RemoveButtonBy = By.Id("remove-sauce-labs-backpack");
        By ContinueShoppingButtonBy = By.Id("continue-shopping");
        By CheckoutButtonBy = By.Id("checkout");
        By FirstAddedItemLinkBy = By.ClassName("inventory_item_name");

        public CartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CartPage(IWebDriver driver) : base(driver, false)
        {
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(ContinueShoppingButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetTitleFirstAddedItem()
        {
            return Driver.FindElement(FirstAddedItemLinkBy).Text;
        }

        public CartPage ClickRemove()
        {
            Driver.FindElement(RemoveButtonBy).Click();

            return this;
        }

        public InventoryPage ReturnToInventoryShoppingPage()
        {
            Driver.FindElement(ContinueShoppingButtonBy).Click();

            return new InventoryPage(Driver, true);
        }

        public CheckoutStepOnePage GoToCheckoutStepOnePage_ClickCheckoutButton()
        {
            Driver.FindElement(CheckoutButtonBy).Click();

            return new CheckoutStepOnePage(Driver, true);
        }

        public CartPage GoToCheckoutPage_WhenCartIsEmpty()
        {
            Driver.FindElement(CheckoutButtonBy).Click();

            return this;
        }
    }
}

