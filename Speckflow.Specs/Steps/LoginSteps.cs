using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Pages;
using TAF_TMS_C1onl.Utilites.Configuration;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps;

[Binding]
public class LoginSteps : BaseSteps
{
    public LoginSteps(ScenarioContext scenarioContext) : base(scenarioContext)
    {
    }
    
    [Given(@"new browser is opened")]
    public void NewBrowserIsOpened()
    {
       
    }

    [Given(@"a login page is displayed")]
    public void ALoginPageIsDisplayed()
    {
        //first method
        //LoginPage loginPage = new LoginPage(Driver);
        //loginPage.NavigateToLogin();
        
        //second method
        //Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
        
        //third
        _navigationSteps.NavigateToLoginPage();
    }

    [Given(@"the user ""(.*)"" with password ""(.*)"" logged in")]
    public void TheUserWithPasswordLoggedIn(string username, string password)
    {
        _navigationSteps.SuccessfulLogin(username, password);
    }
}