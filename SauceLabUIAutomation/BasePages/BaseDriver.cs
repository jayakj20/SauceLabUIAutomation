using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceLabUIAutomation.BasePages
{
    public class BaseDriver
    {
        protected IWebDriver Driver { get; private set; }
        public BaseDriver(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}