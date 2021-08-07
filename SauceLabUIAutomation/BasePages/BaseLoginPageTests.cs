using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceLabUIAutomation.PageObjects;

namespace SauceLabUIAutomation.BasePages
{
    public class BaseLoginPageTests : BaseExtentReporter
    {
        public IWebDriver Driver { get; private set; }
        protected LoginPage LoginPage { get; set; }

        [SetUp]
        public void DoForEveryTest()
        {
            Driver = new ChromeDriver();
            LoginPage = new LoginPage(Driver);
            LoginPage.GoTo();
        }

        [TearDown]
        public void DoAfterEveryTest ()
        {
            Driver.Quit();
        }

    }
}
