using NUnit.Framework;
using TAF_TMS_C1onl.Models;
using TechTalk.SpecFlow;

namespace Speckflow.Specs.Steps.HW.API;

[Binding]
public class ApiSteps : BaseApiSteps
{
    private Case expectedCaseForCreate;
    private Case expectedCaseForUpdate;
    private Case addedCase;
    private Case actualCase;

    [Given("the API client is initialized")]
    public void ApiClientIsInitialized()
    {
    }

    [Given(@"a new case is added with title ""(.*)"" sectionId ""(.*)"" templateId ""(.*)"" typeId ""(.*)"" priorityId ""(.*)"" and estimate ""(.*)""")]
    [When(@"a new case is added with title ""(.*)"" sectionId ""(.*)"" templateId ""(.*)"" typeId ""(.*)"" priorityId ""(.*)"" and estimate ""(.*)""")]
    public void NewCaseIsAdded(string title, int sectionId, int templateId, int typeId, int priorityId, string estimate)
    {
        expectedCaseForCreate = new Case
        {
            Title = title,
            SectionId = sectionId,
            TemplateId = templateId,
            TypeId = typeId,
            PriorityId = priorityId,
            Estimate = estimate
        };

        addedCase = caseService.AddCase(expectedCaseForCreate.SectionId, expectedCaseForCreate);
        actualCase = addedCase;
    }

    [Then("the added case should match the expected details")]
    public void AddedCaseShouldMatchExpectedDetails()
    {
        Assert.Multiple(() =>
        {
            Assert.That(actualCase.Title, Is.EqualTo(expectedCaseForCreate.Title));
            Assert.That(actualCase.SectionId, Is.EqualTo(expectedCaseForCreate.SectionId));
            Assert.That(actualCase.TemplateId, Is.EqualTo(expectedCaseForCreate.TemplateId));
            Assert.That(actualCase.TypeId, Is.EqualTo(expectedCaseForCreate.TypeId));
            Assert.That(actualCase.PriorityId, Is.EqualTo(expectedCaseForCreate.PriorityId));
            Assert.That(actualCase.Estimate, Is.EqualTo(expectedCaseForCreate.Estimate));
        });
        
    }

    [When("the case is updated with new details")]
    public void CaseIsUpdatedWithNewDetails()
    {
        expectedCaseForUpdate = new Case
        {
            Id = addedCase.Id,
            Title = "Updated Test Case",
        };

        actualCase = caseService.UpdateCase(expectedCaseForUpdate.Id, expectedCaseForUpdate);
    }

    [Then("the updated case should match the expected details")]
    public void UpdatedCaseShouldMatchExpectedDetails()
    {
        Assert.Multiple(() =>
        {
            Assert.That(actualCase.Id, Is.EqualTo(addedCase.Id));
            Assert.That(actualCase.Title, Is.EqualTo(expectedCaseForUpdate.Title));
        });
    }

    [When("the case is deleted")]
    public void CaseIsDeleted()
    {
        caseService.DeleteCase(actualCase.Id);
    }

    [Then("the case should be deleted")]
    public void CaseShouldBeDeleted()
    {
        Assert.Throws<HttpRequestException>(() =>
        {
            caseService.GetAsCase(addedCase.Id);
        });
    }
}

