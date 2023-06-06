using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps
{
    [Binding]
    public class SimpleSteps
    {
        [Given("@открыть браузер")]
        public void OpenBrowser()
        {

        }
       
        [Given("@страница логина открыта")]
        [When("@страница логина открыта")]
        public void OpenLoginPage()
        {

        }

        [Then("@поле username отображается")]
        public void IsUsernameFieldDisplayed()
        {
            Assert.IsTrue(true);
        }

        [Then("@поле password отображается")]
        public void IsPasswordFieldDisplayed()
        {
            ScenarioContext.StepIsPending();
        }

        [Then("@ошибка не отобраается")]
        public void IsErrorDisplayed()
        {
      
        }
    }
}


