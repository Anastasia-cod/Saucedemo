using System;
using Core.Models;
using SauceDemo.Page;
using SauceDemo.BaseEntities;
using Core.Models.Builder;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace SauceDemo.Test
{
    public class SmokeTest : BaseTest
    {
        [Test(Description = "Smoke test: Login, Adding items to Cart, CheckOut, Ordering")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Smoke test")]
        [AllureIssue("Issue - smoke test ")]
        [AllureTms("Smoke - 1.1")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with valid credentials can login, adding items to Cart, checkout and ordering aded items")]
        public void SmokeTest_StandartUser()
        {
            //Var
            var standartUser = UserBuilder.StandartUser;

            UserBuilder builder = new UserBuilder();
            var standartUserInfo = builder
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
                .FillInAll_RequiredUserDetails(standartUserInfo)
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

