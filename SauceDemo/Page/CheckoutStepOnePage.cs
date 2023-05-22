using System;
using System.Net;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Models;
using SauceDemo.Test;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckoutStepOnePage : BasePage
    {
        private static string endPoint = "checkout-step-one.html";

        Input firstName = new Input("first-name");
        Input lastName = new Input("last-name");
        Input zipOrPostalCode = new Input("postal-code");
        Button cancel = new Button("cancel");
        Button continueButton = new Button("continue");

        public CheckoutStepOnePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutStepOnePage(IWebDriver driver) : base(driver, false)
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
                return continueButton.CheckIsDisplayed();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public CheckoutStepOnePage SetFirstName(User user)
        {
            this.firstName.FillIn(user.FirstName);

            return this;
        }

        public CheckoutStepOnePage SetLastName(User user)
        {
            this.lastName.FillIn(user.LastName);

            return this;
        }

        public CheckoutStepOnePage SetZipOrPostalCode(User user)
        {
            this.zipOrPostalCode.FillIn(user.ZipPostalCode);

            return this;
        }

        public InventoryPage ClickCancelButton()
        {
            cancel.Click();

            return new InventoryPage(Driver, true);
        }

        public void ClickContinueButton()
        {
            continueButton.Click();
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

