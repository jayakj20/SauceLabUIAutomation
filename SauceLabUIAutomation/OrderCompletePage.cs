using OpenQA.Selenium;

namespace SauceLabUIAutomation
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