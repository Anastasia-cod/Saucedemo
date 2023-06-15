using Speckflow.Specs.Steps;
using TAF_TMS_C1onl.Pages;
using TechTalk.SpecFlow;

namespace Speckflow.Specs;

[Binding]
public class AddProjectSteps : BaseSteps
{
    public AddProjectSteps(ScenarioContext scenarioContext) : base(scenarioContext)
    {
    }
    
    [When(@"the current user switched to add project page")]
    public void WhenTheCurrentUserSwitchedToAddProjectPage()
    {
        _projectSteps.NavigateToAddProjectPage();
    }

    [When(@"entered in the name field ""(.*)""")]
    public void EnteredInTheNameField(string projectName)
    {
       _projectSteps.FillInProjectNameField(projectName);
    }

    [When(@"clicked the add project button")]
    public void WhenClickedTheAddProjectButton()
    {
        _projectSteps.ClickAddNewProjectButton();
    }
}