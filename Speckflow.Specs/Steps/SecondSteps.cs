using NUnit.Framework;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps;

[Binding]
public class SecondSteps
{
    private Browser _browser;
    private NavigationSteps _navigationSteps;
    
    [Given(@"browser is opened")]
    public void BrowserIsOpened()
    {
        _browser = new Browser();
    }

    [Given(@"the login page is opened")]
    public void TheLoginPageIsOpened()
    {
        _navigationSteps = new NavigationSteps(_browser.Driver);
        _navigationSteps.NavigateToLoginPage();
    }

    [When(@"user ""(.*)"" with password ""(.*)"" logged in")]
    public void UserWithPasswordLoggedIn(string username, string password)
    {
        _navigationSteps.SuccessfulLogin(username, password);
    }

    [Then(@"the title is ""(.*)""")]
    public void TheTitleIs(string expectedValue)
    {
        Assert.AreEqual(expectedValue, _browser.Driver.Title);
    }

    //[After()]
    public void TearDown()
    {
        _browser.Driver.Quit();
    }

    [Then(@"project ID is (.*)")]
    public void ThenProjectIdIs(int expectedValue)
    {
        Assert.AreEqual(expectedValue,expectedValue);
    }
}