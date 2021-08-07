using OpenQA.Selenium;
using SauceLabUIAutomation.BasePages;
using System;

namespace SauceLabUIAutomation.PageObjects
{
    public class CheckOutPage : BaseDriver
    {
        public CheckOutPage(IWebDriver driver) : base(driver)
        {}

        private IWebElement FName => Driver.FindElement(By.Id("first-name"));
        private IWebElement LName => Driver.FindElement(By.Id("last-name"));
        private IWebElement PostalCode => Driver.FindElement(By.Id("postal-code"));
        private IWebElement ContinueBtn => Driver.FindElement(By.Id("continue"));

        public void EnterCheckOutInfo(string fName, string lName, string postalCode)
        {
            FName.SendKeys(fName);
            LName.SendKeys(lName);
            PostalCode.SendKeys(postalCode);
        }

        public OverViewPage ClickContinue()
        {
            try
            {
                ContinueBtn.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return new OverViewPage(Driver);
        }
    }
}