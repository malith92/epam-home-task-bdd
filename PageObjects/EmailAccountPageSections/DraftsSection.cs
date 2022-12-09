using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HTSpecFlowProject.PageObjects.EmailAccountPageSections
{
    public class DraftsSection : BasePageObject
    {
        private string _draftedEmailXpath = "//span[text()='$EMAIL_SUBJECT']/parent::span/parent::div";
        private By? _draftedEmailElementLocator;
        private IWebElement? _draftedEmailElement;

        public DraftsSection(IWebDriver driver) : base(driver) { }

        public bool DraftedEmailIsDisplayed(string emailSubject)
        {
            _draftedEmailElementLocator = By.XPath(_draftedEmailXpath.Replace("$EMAIL_SUBJECT", emailSubject));
            bool draftedEmailIsDisplayed;
            try
            {
                _draftedEmailElement = base.DefaultWait.Until(_driver => _driver.FindElement(_draftedEmailElementLocator));

                draftedEmailIsDisplayed = _draftedEmailElement.Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                draftedEmailIsDisplayed = false;
            }

            return draftedEmailIsDisplayed;
        }
        public EmailComposeSection ClickDraftedEmail()
        {
            _draftedEmailElement.Click();

            return new EmailComposeSection(base.Driver);
        }
    }
}
