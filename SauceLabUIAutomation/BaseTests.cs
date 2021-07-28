using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceLabUIAutomation
{
    public class BaseTests 
    {
        public IWebDriver Driver { get; private set; }
        protected LoginPage LoginPage { get; set; }
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
        }

        //Closing the Extent Reporter Instance
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
