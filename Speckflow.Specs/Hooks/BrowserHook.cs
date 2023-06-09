using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Hooks;

public class BrowserHook
{
    private readonly Browser _browser;
    
    public BrowserHook(Browser browser)
    {
        _browser = browser;
    }
    
    [BeforeScenario("GUI")]
    public void BeforeScenario()
    {
        Console.Out.WriteLine("GUI");
    }
    
    [BeforeScenario("GeneralUser")]
    public void GenerateGeneralUser()
    {
        Console.Out.WriteLine("GeneralUser");
    }

    [AfterScenario("GUI")]
    public void AfterScenario()
    {
        _browser.Driver.Quit();
    }
}