using System;
using Core.Models;
using SauceDemo.Page;
using SauceDemo.BaseEntities;
using Core.Models.Builder;

namespace SauceDemo.Test
{
    public class SmokeTest : BaseTest
    {
        [Test, Category("Positive")]
        public void SmokeTest_StandartUser()
        {
            //Var
            UserBuilder builder = new UserBuilder();

            var standartUser = builder
                .SetName("standard_user")
                .SetPassword("secret_sauce")
                .SetFirstName("Anna")
                .SetLastName("Petrova")
                .SetZipOrPostalCode("220029")
                .Build();

            var expectedMessage = "Thank you for your order!";

            //Action
            var checkoutCompletePage = new LoginPage(Driver, true)
                .SuccessfulLogin(standartUser)
                .AddTShirtToCart()
                .AddBackPackToCart()
                .GoToCartPage_ClickShoppingCartLink()
                .GoToCheckoutStepOnePage_ClickCheckoutButton()
                .FillInAll_RequiredUserDetails(standartUser)
                .ClickFinishButton();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(checkoutCompletePage.CheckSuccessOrderMessageIsDislayed, Is.True);
                Assert.That(checkoutCompletePage.GetSuccessOrderMessage, Is.EqualTo(expectedMessage));
            });
        }
    }
}

