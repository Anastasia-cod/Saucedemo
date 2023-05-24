using System;
using System.Xml.Linq;
using Core.Utilities;
using OpenQA.Selenium;
using SauceDemo.BaseEntities;
using Core.Models;
using SauceDemo.Wrappers;
using Core;
using Bogus.DataSets;

namespace SauceDemo.Page
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";

        By UsernameInputBy = By.Id("user-name");
        By PasswordInputBy = By.Id("password");
        By LoginButtonBy = By.Id("login-button");
        By ErrorMessageLocatorBy = By.XPath("//h3[@data-test='error']");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(LoginButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public LoginPage SetUserName(string name)
        {
            Driver.FindElement(UsernameInputBy).SendKeys(name);

            return this;
        }

        public LoginPage SetUserPassword(string password)
        {
            Driver.FindElement(PasswordInputBy).SendKeys(password);

            return this;
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(LoginButtonBy).Click();
        }

        public InventoryPage SuccessfulLogin(User user)
        {
            Login(user);

            return new InventoryPage(Driver, true);
        }

        public LoginPage IncorrectLogin(User user)
        {
            Login(user);

            return this;
        }

        private void Login(User user)
        {
            OpenPage();
            SetUserName(user.UserName);
            SetUserPassword(user.Password);
            ClickLoginButton();
        }

        public bool ErrorMessageIsDisplayed()
        {
            return Driver.FindElement(ErrorMessageLocatorBy).Displayed;
        }

        public string GetErrorMessage_WhenInvalidCredentials()
        {
            return Driver.FindElement(ErrorMessageLocatorBy).Text;
        }
    }
}

