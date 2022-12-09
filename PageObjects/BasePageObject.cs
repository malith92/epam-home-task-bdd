
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace HTSpecFlowProject.PageObjects
{
    public abstract class BasePageObject
    {
        private IWebDriver _driver;
        private DefaultWait<IWebDriver> _defaultWait;
        private WebDriverWait _webDriverWait;

        public BasePageObject(IWebDriver driver)
        {
            _driver = driver;

            // Initialize defaultWait
            _defaultWait = new DefaultWait<IWebDriver>(driver);
            _defaultWait.Timeout = TimeSpan.FromSeconds(5);
            _defaultWait.PollingInterval = TimeSpan.FromMilliseconds(5000);
            _defaultWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _defaultWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            _defaultWait.Message = "Element to be searched not found";

            // Initialize webDriverWait
            _webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebDriver Driver { get => _driver; set => _driver = value; }
        public DefaultWait<IWebDriver> DefaultWait { get => _defaultWait; set => _defaultWait = value; }
        public WebDriverWait WebDriverWait { get => _webDriverWait; set => _webDriverWait = value; }
    }
}
