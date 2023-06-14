using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps;

public class BaseSteps
{
    protected IWebDriver Driver;
    protected NavigationSteps _navigationSteps;
    protected ProjectSteps _projectSteps;
    public BaseSteps(ScenarioContext scenarioContext)
    {
        Driver = scenarioContext.Get<IWebDriver>("Driver");
        _navigationSteps = new NavigationSteps(Driver);
        _projectSteps = new ProjectSteps(Driver);
    }
}