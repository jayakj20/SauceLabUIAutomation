using OpenQA.Selenium;
using SauceLabUIAutomation.BasePages;

namespace SauceLabUIAutomation.PageObjects
{
    public class OrderCompletePage : BaseDriver
    {
        public OrderCompletePage(IWebDriver driver) : base (driver)
        { }

        public IWebElement OrderCompletePageTitle => Driver.FindElement(By.ClassName("title"));

        public bool IsCheckOutComplete()
        {
            if (OrderCompletePageTitle.GetAttribute("innerText").Equals("CHECKOUT: COMPLETE!"))
            {
                return true;
            }
            else return false;
        }
        
    }
}