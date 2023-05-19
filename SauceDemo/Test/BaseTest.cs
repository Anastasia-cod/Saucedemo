using System;
using Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Page;

namespace SauceDemo.Test
{
    public class BaseTest
    {
        public IWebDriver driver;
        public LoginPage LoginPage { get; set; }
        public InventoryPage InventoryPage { get; set; }
        public ItemInfoPage ItemInfoPage { get; set; }
        public CartPage CartPage { get; set; }
        public CheckoutStepOnePage CheckoutStepOnePage { get; set; }
        public CheckOutStepTwoPage CheckOutStepTwoPage { get; set; }
        public CheckoutCompletePage CheckoutCompletePage { get; set; }


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            LoginPage = new LoginPage(driver, true);
            InventoryPage = new InventoryPage(driver, true);
            ItemInfoPage = new ItemInfoPage(driver, true);
            CartPage = new CartPage(driver, true);
            CheckoutStepOnePage = new CheckoutStepOnePage(driver, true);
            CheckOutStepTwoPage = new CheckOutStepTwoPage(driver, true);
            CheckoutCompletePage = new CheckoutCompletePage(driver, true);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}

