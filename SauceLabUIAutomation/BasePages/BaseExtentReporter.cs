using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;

namespace SauceLabUIAutomation.BasePages
{
   public class BaseExtentReporter
    {
        protected ExtentTest test { get; set; }
        protected ExtentReports extent = null;

        // Initializing the Extent Reporter object
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\jjayakumar\Desktop\Automation Projects\SauceLabUIAutomation\SauceLabUIAutomation\TestExecutionResults\HomePageFilterMenuTestResults.html");
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
