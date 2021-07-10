using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceLabUIAutomation
{
    public class BaseTests
    {
        protected IWebDriver Driver { get; set; }
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

        //Closing the Extent Reporter Instance
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
