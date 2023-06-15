using NUnit.Framework;
using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps;

[Binding]
public class SettingsSteps : BaseSteps
{
    public SettingsSteps(ScenarioContext scenarioContext) : base(scenarioContext)
    {
    }
    
    [Then(@"settings page is opened")]
    public void SettingsPageIsOpened()
    {
        Driver.Navigate().GoToUrl("https://aqac01onl01.testrail.io/index.php?/admin/site_settings");
        Assert.AreEqual("Site Settings - TestRail", Driver.Title);
    }
}