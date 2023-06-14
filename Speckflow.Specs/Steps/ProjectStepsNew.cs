using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps;

[Binding]
public class ProjectStepsNew : BaseSteps
{
    public ProjectStepsNew(ScenarioContext scenarioContext) : base(scenarioContext)
    {
    }
    
    [Then(@"the new project is displayed")]
    public void NewProjectIsDisplayed()
    {
        Driver.Navigate().GoToUrl("https://aqac02onl.testrail.io/index.php?/admin/projects/overview");
        
        Assert.True(Driver.FindElement(By.XPath("//a[text()='Anastasiya Project Test 2 - bdd']")).Displayed);
    }

}