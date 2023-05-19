using System;
using System.Xml.Linq;
using Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemo.Models;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class LoginPage : BasePage
    {
        Input userName = new Input("user-name");
        Input password = new Input("password");
        Button login = new Button("login-button");
        By errorMessageLocator = By.XPath("//h3[@data-test='error']");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return login.CheckIsDisplayed();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public LoginPage OpenLoginPage()
        {
            Browser.Instance.NavigateToUrl("https://www.saucedemo.com/");

            return this;
        }

        public LoginPage SetUserName(string name)
        {
            userName.FillIn(name);

            return this;
        }

        public LoginPage SetUserPassword(string password)
        {
            this.password.FillIn(password);

            return this;
        }

        public void ClickLoginButton()
        {
            login.Click();
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
            OpenLoginPage();
            SetUserName(user.Name);
            SetUserPassword(user.Password);
            ClickLoginButton();
        }

        public bool ErrorMessageIsDisplayed()
        {
            return Driver.FindElement(errorMessageLocator).Displayed;
        }

        public string GetErrorMessage_WhenInvalidCredentials()
        {
            return Driver.FindElement(errorMessageLocator).Text;
        }
    }
}

