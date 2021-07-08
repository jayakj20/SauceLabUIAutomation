using OpenQA.Selenium;
using System;

namespace SauceLabUIAutomation
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoTo()
        {
            throw new NotImplementedException();
        }

        public HomePage EnterDetailsAndLogin(string v1, string v2)
        {
            return new HomePage(); 
        }
    }
}