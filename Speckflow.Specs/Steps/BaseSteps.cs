using OpenQA.Selenium;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps;

public class BaseSteps
{
    protected IWebDriver Driver;
    protected NavigationSteps _navigationSteps;
    
    public BaseSteps(ScenarioContext scenarioContext)
    {
        Driver = scenarioContext.Get<IWebDriver>("Driver");
        _navigationSteps = new NavigationSteps(Driver);
    }
}