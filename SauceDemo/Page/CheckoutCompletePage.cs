using System;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckoutCompletePage : BasePage
    {
        Button backHome = new Button("back-to-products");
        By successOrderMessageLocator = By.XPath("//h2[@class='complete-header']");

        public CheckoutCompletePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutCompletePage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-complete.html");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return backHome.CheckIsDisplayed();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public InventoryPage ClickBackHomeButton()
        {
            backHome.Click();

            return new InventoryPage(Driver, true);
        }

        public bool CheckSuccessOrderMessageIsDislayed()
        {
            return Driver.FindElement(successOrderMessageLocator).Displayed;
        }

        public string GetSuccessOrderMessage()
        {
            return Driver.FindElement(successOrderMessageLocator).Text;
        }
    }
}

