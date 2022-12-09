using System.Net.Mail;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HTSpecFlowProject.PageObjects.EmailAccountPageSections
{
    public class EmailComposeSection : BasePageObject
    {
        private readonly By _receiverAddressTxtFieldLocator = By.XPath("//div[@aria-label='Search Field']/div/input");
        private readonly By _subjectTxtFieldLocator = By.Name("subjectbox");
        private readonly By _emailContentFieldLocator = By.XPath("//div[@aria-label='Message Body']");
        private readonly By _closeButtonLocator = By.XPath("//img[@aria-label='Save & close']");

        private readonly By _receiverAddressTxtAfterDraftLocator = By.XPath("//input[@name='from' and @type='hidden']/preceding-sibling::div[2]/div[1]/span");
        private readonly By _subjectTxtAfterDraftLocator = By.Name("subject");
        private readonly By _sendButtonLocator = By.XPath("//div[text()='Send']");

        public EmailComposeSection(IWebDriver driver) : base(driver) { }

        private void TypeReceiverEmailAddress(string emailAddress)
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_receiverAddressTxtFieldLocator)).SendKeys(emailAddress);
        }

        private void TypeEmailSubject(string subject)
        {
            base.Driver.FindElement(_subjectTxtFieldLocator).SendKeys(subject);
        }

        private void TypeEmailContent(string content)
        {
            base.Driver.FindElement(_emailContentFieldLocator).SendKeys(content);
        }

        private void ClickCloseButton()
        {
            base.Driver.FindElement(_closeButtonLocator).Click();
        }

        public void CreateDraftEmail(string emailAddress, string subject, string content)
        {
            this.TypeReceiverEmailAddress(emailAddress);
            this.TypeEmailSubject(subject);
            this.TypeEmailContent(content);
            this.ClickCloseButton();
        }

        public string GetReceiverAddressFromDraftedEmail()
        {           
            string receiverAddressFromDraftedEmail = base.DefaultWait.Until(_driver => _driver.FindElement(_receiverAddressTxtAfterDraftLocator)).Text;

            return receiverAddressFromDraftedEmail;
        }

        public string GetSubjectFromDraftedEmail()
        {
            string subjectFromDraftedEmail = base.Driver.FindElement(_subjectTxtAfterDraftLocator).GetAttribute("value");

            return subjectFromDraftedEmail;
        }

        public string GetContentFromDraftedEmail()
        {
            string contentFromDraftedEmail = base.Driver.FindElement(_emailContentFieldLocator).Text;

            return contentFromDraftedEmail;
        }

        public void ClickSendButton()
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_sendButtonLocator)).Click();
        }
    }
}
