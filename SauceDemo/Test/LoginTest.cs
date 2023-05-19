using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Builder;
using SauceDemo.Page;

namespace SauceDemo.Test
{
    public class LoginTest : BaseTest
    {
        [Test, Category("Positive")]
        public void SuccessfullLogin_StandartUser()
        {
            //Var
            var standartUser = UserBuilder.StandartUser;

            //Action
            var inventoryPage = new LoginPage(Driver, true)
                .SuccessfulLogin(standartUser);

            //Assert
            Assert.That(inventoryPage.CheckInventoryItemLinkIsDisplayed(), Is.True);
        }

        [Test, Category("Negative")]
        public void IncorrectLogin_StandartUserWithIncorrectPassword()
        {
            //Var
            var standartUserWithIncorrectPassword = UserBuilder.StandartUserWithIncorrectPassword;
            var expectedError = "Epic sadface: Username and password do not match any user in this service";

            //Action
            var loginPage = new LoginPage(Driver, true)
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

