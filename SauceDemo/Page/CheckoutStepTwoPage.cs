using System;
using SauceDemo.Wrappers;
using SauceDemo.BaseEntities;
using OpenQA.Selenium;
using Core;
using System.Net;

namespace SauceDemo.Page
{
    public class CheckOutStepTwoPage : BasePage
    {
        private static string END_POINT = "checkout-step-two.html";

        By FinishButtonBy = By.Id("finish");
        By CancelButtonBy = By.Id("cancel");

        public CheckOutStepTwoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckOutStepTwoPage(IWebDriver driver) : base(driver, false)
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
                return Driver.FindElement(FinishButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public InventoryPage ClickCancelButton()
        {
            Driver.FindElement(CancelButtonBy).Click();

            return new InventoryPage(Driver, true);
        }

        public CheckoutCompletePage ClickFinishButton()
        {
            Driver.FindElement(FinishButtonBy).Click();

            return new CheckoutCompletePage(Driver, true);
        }
    }    
}

