using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Services;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps.HW.API;

public class BaseApiSteps
{
    protected ApiClient _apiClient;
    protected CaseService caseService;
    
    public BaseApiSteps()
    {
        _apiClient = new ApiClient();
        caseService = new CaseService(_apiClient);
    }
}