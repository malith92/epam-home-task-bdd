using OpenQA.Selenium;

namespace HTSpecFlowProject.PageObjects
{
    public class AccountChooserPage : BasePageObject
    {
        private readonly By _chooseAccountElementLocator = By.XPath("//span[text()='Choose an account']");
        public AccountChooserPage(IWebDriver driver) : base(driver) { }

        public bool ChooseAccountTextIsDisplayed()
        {
            bool gmailLinkDisplayed = base.DefaultWait.Until(_driver => _driver.FindElement(_chooseAccountElementLocator)).Displayed;

            return gmailLinkDisplayed;
        }
    }
}
