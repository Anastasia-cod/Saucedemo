using System;
using OpenQA.Selenium;
using SauceDemo.Page;

namespace SauceDemo.Steps
{
    public class BaseStep
    {
        protected IWebDriver Driver;

        public LoginPage LoginPage => new LoginPage(Driver);
        public InventoryPage DashboardPage => new InventoryPage(Driver);
        public CartPage AddProjectPage => new CartPage(Driver);

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}

