using System;
using System.Xml.Linq;
using Core.Selenium;
using SauceDemo.Wrappers;

namespace SauceDemo.Page
{
    public class LoginPage : BasePage
    {
        Input userName = new Input("user-name");
        Input password = new Input("password");
        Button login = new Button("login-button");

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

        public InventoryPage SuccessfulLogin(string userName, string password)
        {
            Login(userName, password);

            return new InventoryPage();
        }

        public LoginPage IncorrectLogin(string userName, string password)
        {
            Login(userName, password);

            return this;
        }

        private void Login(string userName, string password)
        {
            OpenLoginPage();
            SetUserName(userName);
            SetUserPassword(password);
            ClickLoginButton();
        }
    }
}

