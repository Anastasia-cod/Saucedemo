using System;
using Core.Models;
using SauceDemo.Page;
using SauceDemo.BaseEntities;
using Core.Models.Builder;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;
using SauceDemo.Steps;
using Core.Utilities.Configuration;

namespace SauceDemo.Test
{
    public class LoginTest : BaseTest
    {
        [Test(Description = "Successful login with valid credentials")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Login")]
        [AllureIssue("Issue - Login with valid credentials ")]
        [AllureTms("Login-1.1")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with valid credentials can login")]
        public void SuccessfullLogin_StandartUser()
        {
            //Action
            NavigationStep.NavigateToLoginPage();

            var inventoryPage = NavigationStep.StandartUserLogin();

            //Assert
            Assert.That(inventoryPage.CheckInventoryItemLinkIsDisplayed(), Is.True);
        }

        [Test(Description = "Incorrect login with invalid credentials")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("User with invalid credentials")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Login")]
        [AllureIssue("Issue - Login with invalid credentials")]
        [AllureTms("Login-1.2")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with invalid username and/or password can not login. Error is appeared")]
        public void IncorrectLogin_StandartUserWithIncorrectName()
        {
            //Var          
            var expectedError = "Epic sadface: Username and password do not match any user in this service";

            //Action
            NavigationStep.NavigateToLoginPage();

            var loginPage = NavigationStep.StandartUserWithIncorrectCredentialsLogin();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(loginPage.ErrorMessageIsDisplayed, Is.True);
                Assert.That(loginPage.GetErrorMessage_WhenInvalidCredentials, Is.EqualTo(expectedError));
            });
        }
    }
}

