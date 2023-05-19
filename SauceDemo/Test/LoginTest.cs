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
            var inventoryPage = LoginPage
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
            var loginPage_ = LoginPage
                .IncorrectLogin(standartUserWithIncorrectPassword);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(LoginPage.ErrorMessageIsDisplayed, Is.True);
                Assert.That(LoginPage.GetErrorMessage_WhenInvalidCredentials, Is.EqualTo(expectedError));
            });
        }
    }
}

