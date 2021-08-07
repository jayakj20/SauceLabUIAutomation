using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            Driver = new ChromeDriver();
            LoginPage = new LoginPage(Driver);
            LoginPage.GoTo();
            LoginPage.EnterCredsAndLogin("standard_user", "secret_sauce");
            HomePage = LoginPage.ValidLogin(LoginPage.LoginStatus());
        }

        [TearDown]
        public void DoAfterEveryTest()
        {
            Driver.Quit();
        }


    }
}