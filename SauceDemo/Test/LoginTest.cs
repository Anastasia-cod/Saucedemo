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
    public class LoginTest : BaseTest
    {
        [Test(Description = "Successful login")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue("TMS-12")]
        [AllureTms("TMS-13")]
        [AllureTag("Smoke")]
        [AllureLink("https://onliner.by")]
        [Description("Более детализированное описание теста")]
        public void SuccessfullLogin_StandartUser()
        {
            //Var
            UserBuilder builder = new UserBuilder();

            User standartUser = builder
                .SetName("standard_user")
                .SetPassword("secret_sauce")
                .Build();

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
            UserBuilder builder = new UserBuilder();

            User standartUserWithIncorrectPassword = builder
                .SetName("standard_user")
                .SetPassword("secret_sauce_1")
                .Build();
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

