using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HTSpecFlowProject.PageObjects.EmailAccountPageSections
{
    public class SentSection : BasePageObject
    {
        private string _sentEmailXpath = "//span[text()='$EMAIL_SUBJECT']/parent::span/parent::div";
        private By? _sentEmailElementLocator;
        private IWebElement? _sentEmailElement;

        public SentSection(IWebDriver driver) : base(driver) { }

        public bool SentEmailIsDisplayed(string emailSubject)
        {
            _sentEmailElementLocator = By.XPath(_sentEmailXpath.Replace("$EMAIL_SUBJECT", emailSubject));
            bool sentEmailIsDisplayed;
            try
            {
                _sentEmailElement = base.DefaultWait.Until(_driver => _driver.FindElement(_sentEmailElementLocator));

                sentEmailIsDisplayed = _sentEmailElement.Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                sentEmailIsDisplayed = false;
            }

            return sentEmailIsDisplayed;
        }
    }
}
