using OpenQA.Selenium;
using System;

namespace SauceLabUIAutomation
{
    public class OverViewPage : BaseDriver
    {
        public OverViewPage(IWebDriver driver) : base(driver)
        {}

        private IWebElement CheckOutItemName => Driver.FindElement(By.ClassName("inventory_item_name"));
        private IWebElement FinishBtn => Driver.FindElement(By.Id("finish"));

        public string GetCheckOutItem()
        {
            return CheckOutItemName.GetAttribute("innerText");
        }

        public OrderCompletePage Finish()
        {
            try
            {
                FinishBtn.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return new OrderCompletePage(Driver);
        }
    }
}