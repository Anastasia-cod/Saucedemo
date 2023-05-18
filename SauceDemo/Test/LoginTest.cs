using System;
using SauceDemo.Builder;
using SauceDemo.Models;
using SauceDemo.Page;

namespace SauceDemo.Test
{
    public class LoginTest : BaseTest
    {
        [Test, Category("Positive")]
        public void SuccessfullLogin_StandartUser()
        {
            //Var
            UserBuilder builder = new UserBuilder();

            User standartUser = builder
                .SetName(TestContext.Parameters.Get("StandartUserName"))
                .SetPassword(TestContext.Parameters.Get("StandartUserPassword"))
                .Build();

            //Action
            var inventoryPage = new LoginPage()
                .SuccessfulLogin(standartUser);

            //Assert
            Assert.That(inventoryPage.CheckInventoryItemLinkIsDisplayed(), Is.True);
        }

        [Test, Category("Negative")]
        public void IncorrectLogin_StandartUserWithIncorrectPassword()
        {
            //Var
            UserBuilder builder = new UserBuilder();

            User standartUserWithIncorrectPassword = builder
                .SetName(TestContext.Parameters.Get("StandartUserName"))
                .SetPassword(TestContext.Parameters.Get("IncorrectPassword"))
                .Build();

            var expectedError = "Epic sadface: Username and password do not match any user in this service";

            //Action
            var loginPage = new LoginPage()
                .IncorrectLogin(standartUserWithIncorrectPassword);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(loginPage.ErrorMessageIsDisplayed, Is.True);
                Assert.That(loginPage.GetErrorMessage_WhenInvalidCredentials, Is.EqualTo(expectedError));
            });
        }
    }
}

