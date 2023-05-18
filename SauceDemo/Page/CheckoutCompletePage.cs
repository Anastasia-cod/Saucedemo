using System;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckoutCompletePage : BasePage
    {
        Button backHome = new Button("back-to-products");
        Text successOrder = new Text(By.XPath("//h2[@class='complete-header']"));

        public InventoryPage ClickBackHomeButton()
        {
            backHome.Click();

            return new InventoryPage();
        }

        public bool CheckSuccessOrderMessageIsDislayed()
        {
            return successOrder.CheckIsDisplayed();
        }

        public string GetSuccessOrderMessage()
        {
            return successOrder.GetText();
        }
    }
}

