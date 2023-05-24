using System;
using System.Xml.Linq;
using Core;
using OpenQA.Selenium;
using SauceDemo.BaseEntities;
using Core.Models;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckoutStepOnePage : BasePage
    {
        private static string END_POINT = "checkout-step-one.html";

        By FirstNameInputBy = By.Id("first-name");
        By LastNameInputBy = By.Id("last-name");
        By ZipOrPostalCodeInputBy = By.Id("postal-code");
        By CancelButtonBy = By.Id("cancel");
        By ContinueButtonBy = By.Id("continue");

        public CheckoutStepOnePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutStepOnePage(IWebDriver driver) : base(driver, false)
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
                return Driver.FindElement(ContinueButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public CheckoutStepOnePage SetFirstName(User user)
        {
            Driver.FindElement(FirstNameInputBy).SendKeys(user.FirstName);

            return this;
        }

        public CheckoutStepOnePage SetLastName(User user)
        {
            Driver.FindElement(LastNameInputBy).SendKeys(user.LastName);

            return this;
        }

        public CheckoutStepOnePage SetZipOrPostalCode(User user)
        {
            Driver.FindElement(ZipOrPostalCodeInputBy).SendKeys(user.ZipPostalCode);

            return this;
        }

        public InventoryPage ClickCancelButton()
        {
            Driver.FindElement(CancelButtonBy).Click();

            return new InventoryPage(Driver, true);
        }

        public void ClickContinueButton()
        {
            Driver.FindElement(ContinueButtonBy).Click();
        }

        public CheckOutStepTwoPage FillInAll_RequiredUserDetails(User user)
        {
            FillInUserDetaildInfo_ClickContinueButton(user);

            return new CheckOutStepTwoPage(Driver, true);
        }

        public CheckoutStepOnePage FillInNotAll_RequiredUserDetails(User user)
        {
            FillInUserDetaildInfo_ClickContinueButton(user);

            return this;
        }

        private void FillInUserDetaildInfo_ClickContinueButton(User user)
        {
            SetFirstName(user);
            SetLastName(user);
            SetZipOrPostalCode(user);
            ClickContinueButton();
        }
    }
}

