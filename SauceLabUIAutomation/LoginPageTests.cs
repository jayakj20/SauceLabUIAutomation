using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SauceLabUIAutomation
{
    [TestFixture]
    [Category("Login Variations")]
    public class LoginPageTests
    {
        //Test Class Properties
        public IWebDriver Driver { get; set; }
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void ExtentStart ()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\jjayakumar\Desktop\Automation Projects\SauceLabUIAutomation\SauceLabUIAutomation\TestExecutionResults\LoginPageTestResults.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        [Description("Login with Standard User - Correct Username/Password")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void SuccessfulLoginTest()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.GoTo();
            var homePage = loginPage.EnterDetailsAndLogin("standard_user", "secret_sauce");
            Assert.That(homePage.GetType(), Is.EqualTo(typeof(HomePage))); 

        }
    }
}