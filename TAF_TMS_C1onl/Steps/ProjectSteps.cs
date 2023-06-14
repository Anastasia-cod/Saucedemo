using OpenQA.Selenium;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Pages;

namespace TAF_TMS_C1onl.Steps;

public class ProjectSteps : BaseStep
{
    public ProjectSteps(IWebDriver driver) : base(driver)
    {
    }

    public void NavigateToAddProjectPage()
    {
        new AddProjectPage(Driver, true);
    }
    
    public void FillInProjectNameField(string projectName)
    {
        AddProjectPage.NameInput.SendKeys(projectName);
    }
    
    public void ClickAddNewProjectButton()
    {
        AddProjectPage.AddProjectButton().Click();
    }
    
    public void CreateProject(Project project)
    {
        AddProjectPage.NameInput.SendKeys(project.Name);
        AddProjectPage.AddProjectButton().Click();
    }
    
}