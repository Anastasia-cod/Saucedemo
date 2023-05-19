using System;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckOutStepTwoPage : BasePage
    {
        Button finish = new Button("finish");
        Button cancel = new Button("cancel");

        public CheckOutStepTwoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckOutStepTwoPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-step-two.html");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return finish.CheckIsDisplayed();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public InventoryPage ClickCancelButton()
        {
            cancel.Click();

            return new InventoryPage(Driver, true);
        }

        public CheckoutCompletePage ClickFinishButton()
        {
            finish.Click();

            return new CheckoutCompletePage(Driver, true);
        }
    }    
}

