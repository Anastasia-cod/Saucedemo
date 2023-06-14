using OpenQA.Selenium;
using TAF_TMS_C1onl.Wrappers;

namespace TAF_TMS_C1onl.Pages
{
    public class AddProjectPage : BasePage
    {
        private static string END_POINT = "index.php?/admin/projects/add";
        
        // Описание элементов
        private static readonly By NameInputBy = By.Id("name");
        private static readonly By AddProjectButtonBy = By.Id("accept");
        
        
        public AddProjectPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public AddProjectPage(IWebDriver? driver) : base(driver, false)
        {
        }
        
        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(NameInputBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }
        
        public Input ProjectNameInput()
        {
            return new Input(Driver, NameInputBy);  
        }
        
        public Button AddProjectButton()
        {
            return new Button(Driver, AddProjectButtonBy);
        }
        public IWebElement NameInput => Driver.FindElement(NameInputBy);
    }
}