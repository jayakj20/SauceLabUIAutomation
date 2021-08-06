using OpenQA.Selenium;
using System;

namespace SauceLabUIAutomation
{
    public class CartPage : BaseDriver
    {
    public IWebElement CheckOutBtn => Driver.FindElement(By.Id("checkout"));
        public CartPage(IWebDriver driver) : base(driver)
        {}
        public CheckOutPage ClickCheckOutBtn()
        {
            try
            {
                CheckOutBtn.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return new CheckOutPage(Driver);
        }
    }
}
