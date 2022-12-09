using OpenQA.Selenium;

namespace HTSpecFlowProject.PageObjects.EmailAccountPageSections
{
    public class AccountSection : BasePageObject
    {
        private readonly By _signOutElementLocator = By.XPath("//div[text()='Sign out']");

        public AccountSection(IWebDriver driver) : base(driver) { }

        private void SwitchFrame()
        {
            base.Driver.SwitchTo().Frame("account");
        }

        private void ClickSignOut()
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_signOutElementLocator)).Click();
        }

        public AccountChooserPage SignOut()
        {
            this.SwitchFrame();
            this.ClickSignOut();

            return new AccountChooserPage(base.Driver);
        }
    }
}
