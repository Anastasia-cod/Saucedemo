using System;
using SauceDemo.Builder;
using SauceDemo.Page;

namespace SauceDemo.Test
{
	public class LoginTest
	{
        [Test, Category("Positive")]
        public void SuccessfullLogin_StandartUser()
        {
            //Var
            var standartUser = UserBuilder.StandartUser;

            //Action
            var inventoryPage = new LoginPage()
                .SuccessfulLogin(standartUser);

            //Assert
            Assert.That(inventoryPage.CheckInventoryItemLinkIsDisplayed(), Is.True);
        }

        [Test, Category("Negative")]
        public void IncorrectLogin_StandartUser()
        {
            //Var
            var standartUserWithIncorrectPassword = UserBuilder.StandartUserWithIncorrectPassword;

            //Action
            var inventoryPage = new LoginPage()
                .SuccessfulLogin(standartUserWithIncorrectPassword);

            //Assert
            Assert.That(inventoryPage.CheckInventoryItemLinkIsDisplayed(), Is.False);
        }
    }
}

