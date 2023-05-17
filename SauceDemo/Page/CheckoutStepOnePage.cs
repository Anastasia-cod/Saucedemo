using System;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckoutStepOnePage : BasePage
    {
        Input firstName = new Input("first-name");
        Input lastName = new Input("lastName");
        Input zipOrPostalCode = new Input("postal-code");
        Button cancel = new Button("cancel");
        Button continueButton = new Button("continue");

        public CheckoutStepOnePage SetFirstName(string firstName)
        {
            this.firstName.FillIn(firstName);

            return this;
        }

        public CheckoutStepOnePage SetLastName(string lastName)
        {
            this.lastName.FillIn(lastName);

            return this;
        }

        public CheckoutStepOnePage SetZipOrPostalCode(string zipOrPostalCode)
        {
            this.zipOrPostalCode.FillIn(zipOrPostalCode);

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

        public CheckOutStepTwoPage FillInAll_RequiredUserDetails(string firstName, string lastName, string zipOrPostalCode)
        {
            FillInUserDetaildInfo_ClickContinueButton(firstName, lastName, zipOrPostalCode);

            return new CheckOutStepTwoPage();
        }

        public CheckoutStepOnePage FillInNotAll_RequiredUserDetails(string firstName, string lastName, string zipOrPostalCode)
        {
            FillInUserDetaildInfo_ClickContinueButton(firstName, lastName, zipOrPostalCode);

            return this;
        }

        private void FillInUserDetaildInfo_ClickContinueButton(string firstName, string lastName, string zipOrPostalCode)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetZipOrPostalCode(zipOrPostalCode);
        }
    }
}

