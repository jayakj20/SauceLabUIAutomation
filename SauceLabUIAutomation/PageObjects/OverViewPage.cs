using OpenQA.Selenium;
using SauceLabUIAutomation.BasePages;
using System;
using System.Collections.Generic;

namespace SauceLabUIAutomation.PageObjects
{
    public class OverViewPage : BaseDriver
    {
        public OverViewPage(IWebDriver driver) : base(driver)
        {}

        private IList <IWebElement> CheckOutItemName => Driver.FindElements(By.ClassName("inventory_item_name"));
        private IWebElement FinishBtn => Driver.FindElement(By.Id("finish"));

        public string GetCheckOutItem(int itemIndex)
        {
            return CheckOutItemName[itemIndex].GetAttribute("innerText");
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