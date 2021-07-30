using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SauceLabUIAutomation
{
    public class BaseHomePageTests { 
        public LoginPage LoginPage { get; private set; }
        public IWebDriver Driver { get; private set; }
        public HomePage HomePage { get; private set; }
        protected ExtentTest test { get; set; }
        protected ExtentReports extent = null;

        // Initializing the Extent Reporter object
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\jjayakumar\Desktop\Automation Projects\SauceLabUIAutomation\SauceLabUIAutomation\TestExecutionResults\LoginPageTestResults.html");
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void DoForEveryTest()
        {
            LoginPage = new LoginPage(Driver);
            LoginPage.GoTo();
            LoginPage.EnterCredsAndLogin("standard_user", "secret_sauce");
            HomePage = LoginPage.ValidLogin(LoginPage.LoginStatus());
        }

        //Closing the Extent Reporter Instance
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }


    }
}