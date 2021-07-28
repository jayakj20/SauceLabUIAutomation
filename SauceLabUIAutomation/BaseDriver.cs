using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceLabUIAutomation
{
    public class BaseDriver
    {
        protected IWebDriver Driver { get; private set; }
        public BaseDriver(IWebDriver driver)
        {
            Driver = driver;
        }

        public void InitChromeDriver ()
        {
            Driver = new ChromeDriver();
        }

        public void QuitDriver()
        {
            Driver.Quit();
        }

    }
}