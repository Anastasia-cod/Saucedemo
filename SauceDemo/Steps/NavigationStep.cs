using System;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using Core.Models;
using SauceDemo.Page;
using Core.Models.Builder;

namespace SauceDemo.Steps
{
    public class NavigationStep : BaseStep
    {
        public NavigationStep(IWebDriver driver) : base(driver) { }

        [AllureStep("Navigate to Login page")]
        public LoginPage NavigateToLoginPage()
        {
            return new LoginPage(Driver, true);
        }

        [AllureStep("Enter valid standart user credentials - switching to Inventory page")]
        public InventoryPage StandartUserLogin() =>
            new LoginPage(Driver, true).SuccessfulLogin(UserBuilder.StandartUser);

        [AllureStep("Enter invalid standart user credentials - remain Login page")]
        public LoginPage StandartUserWithIncorrectCredentialsLogin() =>
           new LoginPage(Driver, true).IncorrectLogin(UserBuilder.StandartUserWithInvalidName);
    }
}

