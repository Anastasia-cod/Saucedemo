using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps;

[Binding]
public class DashboardSteps : BaseSteps
{
    public DashboardSteps(ScenarioContext scenarioContext) : base(scenarioContext)
    {
    }
    
    [When(@"dashboard page is opened")]
    [Then(@"dashboard page is opened")]
    public void DashboardPageIsOpened()
    {
        Assert.AreEqual("All Projects - TestRail", Driver.Title);
    }
    
    public void WhenDashboardPageIsOpened()
    {
        ScenarioContext.StepIsPending();
    }
}