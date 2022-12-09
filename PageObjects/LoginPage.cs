using OpenQA.Selenium;

namespace HTSpecFlowProject.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly By _emailAddressFieldLocator = By.Id("identifierId");
        private readonly By _emailAddressNextButtonLocator = By.XPath("//div[@id='identifierNext']/div/button");
        private readonly By _passwordFieldLocator = By.Name("Passwd");
        private readonly By _passwordNextButtonLocator = By.XPath("//div[@id='passwordNext']/div/button");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void EnterUserName(string userName)
        {
            base.Driver.FindElement(_emailAddressFieldLocator).SendKeys(userName);
        }

        public void ClickNextAfterEnteringUserName()
        {
            base.Driver.FindElement(_emailAddressNextButtonLocator).Click();
        }

        public void EnterPassword(string password)
        {
            base.DefaultWait.Until(_driver => _driver.FindElement(_passwordFieldLocator)).SendKeys(password);
        }

        public void ClickNextAfterEnteringPassword()
        {
            base.Driver.FindElement(_passwordNextButtonLocator).Click();
        }

        public EmailAccountHomePage Login(string userName, string password)
        {
            this.EnterUserName(userName);
            this.ClickNextAfterEnteringUserName();
            this.EnterPassword(password);
            this.ClickNextAfterEnteringPassword();

            return new EmailAccountHomePage(base.Driver);
        }
    }
}
