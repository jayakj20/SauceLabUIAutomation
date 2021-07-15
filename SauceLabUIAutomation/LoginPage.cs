using OpenQA.Selenium;
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

        public string LoginStatus()
        {
            var status = "Passed, Successful Login";
            try
            {
                string errorMessage = ErrorMessage.GetAttribute("innerText");

                if (errorMessage.Equals("Epic sadface: Username is required"))
                {
                    status = "Failed, Username and Password must be enterred";
                }
                else if (errorMessage.Equals("Epic sadface: Password is required"))
                {
                    status = "Failed, Password Required";
                }
                else if (errorMessage.Equals("Epic sadface: Username and password do not match any user in this service"))
                {
                    status = "Failed, Username and Password do not Match";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return status;
        }
        public HomePage ValidLogin(string status)
        {
            if (status.Equals("Passed, Successful Login"))
            {
                return new HomePage(Driver);
            }
            else return null;
        }
          
    }
}