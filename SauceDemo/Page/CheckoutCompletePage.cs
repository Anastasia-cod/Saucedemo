using System;
using Core;
using OpenQA.Selenium;
using SauceDemo.BaseEntities;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckoutCompletePage : BasePage
    {
        private static string END_POINT = "checkout-complete.html";

        By BackHomeButtonBy = By.Id("back-to-products");
        By SuccessOrderMessageElementBy = By.XPath("//h2[@class='complete-header']");

        public CheckoutCompletePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutCompletePage(IWebDriver driver) : base(driver, false)
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
                return Driver.FindElement(BackHomeButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public InventoryPage ClickBackHomeButton()
        {
            Driver.FindElement(BackHomeButtonBy).Click();

            return new InventoryPage(Driver, true);
        }

        public bool CheckSuccessOrderMessageIsDislayed()
        {
            return Driver.FindElement(SuccessOrderMessageElementBy).Displayed;
        }

        public string GetSuccessOrderMessage()
        {
            return Driver.FindElement(SuccessOrderMessageElementBy).Text;
        }
    }
}

