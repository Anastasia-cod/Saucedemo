using System;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckoutCompletePage : BasePage
    {
        Button backHome = new Button("back-to-products");
        By successOrderMessageLocator = By.XPath("//h2[@class='complete-header']");

        public InventoryPage ClickBackHomeButton()
        {
            backHome.Click();

            return new InventoryPage();
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

