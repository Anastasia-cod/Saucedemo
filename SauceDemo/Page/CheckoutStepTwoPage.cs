using System;
using System.Net;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Test;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckOutStepTwoPage : BasePage
    {
        private static string endPoint = "checkout-step-two.html";

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
            Browser.Instance.NavigateToUrl(BaseTest.baseUrl + endPoint);
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

