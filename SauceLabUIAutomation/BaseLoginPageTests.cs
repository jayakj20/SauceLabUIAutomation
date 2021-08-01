using NUnit.Framework;
using OpenQA.Selenium;

namespace SauceLabUIAutomation
{
    public class BaseLoginPageTests : BaseExtentReporter
    {
        public IWebDriver Driver { get; private set; }
        protected LoginPage LoginPage { get; set; }

        [SetUp]
        public void DoForEveryTest()
        {
            LoginPage = new LoginPage(Driver);
            LoginPage.GoTo();
        }

    }
}
