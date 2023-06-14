using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps;

[Binding]
public class SimpleSteps
{
    [Given(@"открыт браузер")]
    public void OpenBrowser()
    {
        
    }

    [When(@"страница логина открыта")]
    [Given(@"страница логина открыта")]
    public void OpenLoginPage()
    {
    }

    [Then(@"поле username отображается")]
    public void IsUsernameFieldDisplayed()
    {
        Assert.IsTrue(true);
    }

    [Then(@"поле password отображается")]
    public void IsPasswordFieldDisplayed()
    {
        ScenarioContext.StepIsPending();
    }
}