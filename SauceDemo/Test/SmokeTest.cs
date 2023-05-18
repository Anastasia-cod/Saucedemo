using System;
using SauceDemo.Builder;
using SauceDemo.Models;
using SauceDemo.Page;

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
                .SetName(TestContext.Parameters.Get("StandartUserName"))
                .SetPassword(TestContext.Parameters.Get("StarndartUserPassword"))
                .SetFirstName("Ivan")
                .SetLastName("Ivanov")
                .SetZipOrPostalCode("12345")
                .Build();

            var expectedMessage = "Thank you for your order!";

            //Action
            var checkoutCompletePage = new LoginPage()
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

