using OpenQA.Selenium;

namespace HTSpecFlowProject.PageObjects
{
    public abstract class BasePage : BasePageObject
    {
        public BasePage(IWebDriver driver) : base(driver) 
        {
            //WaitUntilPageLoads();
        }

        public void WaitUntilPageLoads()
        {
            base.WebDriverWait.Until((IWebDriver driver) =>
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;

                string script = "return document.readyState";

                bool scriptOutput = javaScriptExecutor.ExecuteScript(script).Equals("complete");

                return scriptOutput;
            });
        }
    }
}
