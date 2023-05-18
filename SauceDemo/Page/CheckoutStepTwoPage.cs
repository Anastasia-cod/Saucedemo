using System;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class CheckOutStepTwoPage : BasePage
    {
        Button finish = new Button("finish");
        Button cancel = new Button("cancel");

        public InventoryPage ClickCancelButton()
        {
            cancel.Click();

            return new InventoryPage();
        }

        public CheckoutCompletePage ClickFinishButton()
        {
            finish.Click();

            return new CheckoutCompletePage();
        }
    }    
}

