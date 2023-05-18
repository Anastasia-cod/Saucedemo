﻿using System;
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
            var standartUser = UserBuilder.StandartUser;
            var expectedMessage = "Thank you for your order!";

            //Action
            var checkoutCompletePage = new LoginPage()
                .SuccessfulLogin(standartUser)
                .AddTShirtToCart()
                .GoToCartPage()
                .GoToCheckoutStepOnePage()
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

