using System;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Models;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckoutStepOnePage : BasePage
    {
        Input firstName = new Input("first-name");
        Input lastName = new Input("last-name");
        Input zipOrPostalCode = new Input("postal-code");
        Button cancel = new Button("cancel");
        Button continueButton = new Button("continue");

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

            return new InventoryPage();
        }

        public void ClickContinueButton()
        {
            continueButton.Click();
        }

        public CheckOutStepTwoPage FillInAll_RequiredUserDetails(User user)
        {
            FillInUserDetaildInfo_ClickContinueButton(user);

            return new CheckOutStepTwoPage();
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

