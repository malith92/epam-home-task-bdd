using System;
using HTSpecFlowProject.Drivers;
using HTSpecFlowProject.PageObjects;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HTSpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginSD
    {
        LoginPage loginPage;
        EmailAccountHomePage emailAccountPage;

        BaseTest test;

        IWebDriver driver;

        [Given(@"user in the login page")]
        public void GivenUserInTheLoginPage()
        {
            test = new BaseTest();

            driver = test.BrowserSetup();

            loginPage = new LoginPage(driver);
        }

        [When(@"user enter '([^']*)', '([^']*)' and clicks on the login button")]
        public void WhenUserEnterAndClicksOnTheLoginButton(string Username, string Password)
        {
            emailAccountPage = loginPage.Login(Username, Password);
        }

        [Then(@"user navigate to home page")]
        public void ThenUserNavigateToHomePage()
        {
            bool loginSuccessful = emailAccountPage.GMailImageIsDisplayed();

            Assert.IsTrue(loginSuccessful);
        }
    }
}
