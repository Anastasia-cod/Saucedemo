using TAF_TMS_C1onl.Clients;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Hooks;

public class ApiClientHook
{
    private readonly ApiClient _apiClient;
    
    public ApiClientHook(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    [BeforeScenario("API")]
    public void BeforeScenario()
    {
        Console.Out.WriteLine("API");
    }
}
