using HomeTaskDesignPatterns.Utilities;
using HTSpecFlowProject.Drivers;
using HTSpecFlowProject.PageObjects;
using HTSpecFlowProject.PageObjects.EmailAccountPageSections;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HTSpecFlowProject.StepDefinitions
{
    [Binding]
    public class EmailOperationsSD
    {
        ConfigurationFileReader? configurationFileReader;
        BaseTest test;
        IWebDriver driver;

        private LoginPage? _loginPage;
        private EmailAccountHomePage? _emailAccountPage;
        private EmailComposeSection? _composeSection;
        private DraftsSection? _draftsSection;
        private SentSection? _sentSection;

        private string? _subject;

        [Given(@"user logged into the home page")]
        public void GivenUserLoggedIntoTheHomePage()
        {
            configurationFileReader = ConfigurationFileReader.GetInstance();

            test = new BaseTest();

            driver = test.BrowserSetup();

            _loginPage = new LoginPage(driver);

            _emailAccountPage = _loginPage.Login(configurationFileReader!.TestData!.EmailCredentials!.UserName!, configurationFileReader!.TestData!.EmailCredentials!.Password!);
        }

        [When(@"user creates a draft email")]
        public void WhenUserCreatesADraftEmail()
        {
            _composeSection = _emailAccountPage!.ClickComposeButton();
            _subject = "Test Email | " + DateTime.Now.ToString("F");
            _composeSection.CreateDraftEmail("malithwanniarachchi@gmail.com", _subject, "Test Email Content");
        }

        [Then(@"drafted email is present in the drafts")]
        public void ThenDraftedEmailIsPresentInTheDrafts()
        {
            _draftsSection = _emailAccountPage.ClickDraftsLink();
            bool draftedEmailIsAvailable = _draftsSection.DraftedEmailIsDisplayed(_subject);

            Assert.IsTrue(draftedEmailIsAvailable);
        }

        [Then(@"drafted email should have the correct receiver, subject, body")]
        public void ThenDraftedEmailShouldHaveTheCorrectReceiverSubjectBody()
        {
            _composeSection = _draftsSection.ClickDraftedEmail();

            string actualReceiverAddress = _composeSection.GetReceiverAddressFromDraftedEmail();

            Assert.AreEqual("malithwanniarachchi@gmail.com", actualReceiverAddress);

            string draftedEmailSubject = _composeSection.GetSubjectFromDraftedEmail();

            Assert.AreEqual(this._subject, draftedEmailSubject);

            string draftedEmailBody = _composeSection.GetContentFromDraftedEmail();

            Assert.AreEqual("Test Email Content", draftedEmailBody);
        }

        [When(@"user sends the email")]
        public void WhenUserSendsTheEmail()
        {
            _composeSection.ClickSendButton();
        }

        [Then(@"email should dissapear from drafts")]
        public void ThenEmailShouldDissapearFromDrafts()
        {
            bool draftedEmailIsDisplayed = _draftsSection.DraftedEmailIsDisplayed(_subject);

            Assert.IsFalse(draftedEmailIsDisplayed);
        }

        [Then(@"sent email is present in the sent section")]
        public void ThenSentEmailIsPresentInTheSentSection()
        {
            _sentSection = _emailAccountPage.ClickSentLink();

            bool sentEmailIsDisplayed = _sentSection.SentEmailIsDisplayed(_subject);

            Assert.IsTrue(sentEmailIsDisplayed);
        }
    }
}
