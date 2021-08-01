using NUnit.Framework;
using OpenQA.Selenium;

namespace SauceLabUIAutomation
{
    public class BaseHomePageTests : BaseExtentReporter
    
    { 
        public LoginPage LoginPage { get; private set; }
        public IWebDriver Driver { get; private set; }
        public HomePage HomePage { get; private set; }

        [SetUp]
        public void DoForEveryTest()
        {
            LoginPage = new LoginPage(Driver);
            LoginPage.GoTo();
            LoginPage.EnterCredsAndLogin("standard_user", "secret_sauce");
            HomePage = LoginPage.ValidLogin(LoginPage.LoginStatus());
        }


    }
}