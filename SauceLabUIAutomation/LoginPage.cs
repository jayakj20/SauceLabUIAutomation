using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SauceLabUIAutomation
{
    public class LoginPage : BaseDriver
    {
        private IWebElement UserNameField => Driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("password"));
        private IWebElement LogintBtn => Driver.FindElement(By.Id("login-button"));
        private IWebElement ErrorMessage => Driver.FindElement(By.ClassName("error-message-container"));
        public LoginPage(IWebDriver driver) : base (driver)
        { }
        
        public void GoTo()
        {
            InitChromeDriver();
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        public void EnterCredsAndLogin(string userName, string password)
        {
            UserNameField.SendKeys(userName);
            PasswordField.SendKeys(password);
            LogintBtn.Click();

        }
        public HomePage IsCredentialsValid()
        {
            HomePage result = new HomePage(Driver);
            try
            {
                if (ErrorMessage.Displayed)
                {
                    result = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return result;
            }
            return result;
        }
          
    }
}