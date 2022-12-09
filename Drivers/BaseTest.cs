using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HTSpecFlowProject.Drivers
{
    
    public class BaseTest
    {
        public static IWebDriver driver;

        public IWebDriver BrowserSetup()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Url = "https://accounts.google.com/ServiceLogin/signinchooser?service=mail";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            return driver;
        }
    }
}
