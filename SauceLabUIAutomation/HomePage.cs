using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SauceLabUIAutomation
{
    public class HomePage : BaseDriver
    {
        private IWebElement FilterDropDown => Driver.FindElement(By.ClassName("product_sort_container"));
        private IList<IWebElement> ItemNames => Driver.FindElements(By.ClassName("inventory_item_name"));
        private IList<IWebElement> ItemPrices => Driver.FindElements(By.ClassName("inventory_item_price"));
        private IWebElement HamburgerMenuBtn => Driver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement About => Driver.FindElement(By.Id("about_sidebar_link"));
        private IWebElement Logout => Driver.FindElement(By.Id("logout_sidebar_link"));
        private IWebElement BackPackAddBtn => Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement ResetAppStateBtn => Driver.FindElement(By.Id("reset_sidebar_link"));
        public IWebElement RemoveBtn => Driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        public IWebElement ShoppingCartBtn => Driver.FindElement(By.ClassName("shopping_cart_link"));
        public IList<IWebElement> AddToCartBtns => Driver.FindElements(By.ClassName("btn_inventory"));

        public HomePage(IWebDriver driver) : base(driver)
        {}

        public void SelectDropdownOption(int index)
        {
            SelectElement select = new(FilterDropDown);
            select.SelectByIndex(index);

        }

        public bool IsItemsOrderedAlphabetically()
        {
            if (ItemNames[0].GetAttribute("innerText").Equals("Sauce Labs Backpack") && ItemNames[ItemNames.Count - 1].GetAttribute("innerText").Equals("Test.allTheThings() T-Shirt (Red)"))
            {
                return true;
            }
            else return false;

        }

        public bool IsItemsOrderedbyPriceLowToHigh()
        {
            if (ItemPrices[0].GetAttribute("innerText").Equals("$7.99") && ItemPrices[ItemPrices.Count - 1].GetAttribute("innerText").Equals("$49.99"))
            {
                return true;
            }
            else return false;
        }

        public void ClickHamburgerMenu()
        {
            HamburgerMenuBtn.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(About));
        }

        public string SelectAbout ()
        {
            About.Click();
            return Driver.Title;
        }

        public string SelectLogout()
        {
            Logout.Click();
            return Driver.Title;
        }

        public bool ResetAppState()
        {
            ResetAppStateBtn.Click();
            try
            {
                if (RemoveBtn.Displayed || ShoppingCartBtn.GetAttribute("innerText").Equals("1"))
                {
                    return false;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;

        }

        public void AddItemToCart (int itemIndex)
        {
            AddToCartBtns[itemIndex].Click();
        }

        public CartPage ClickCartBtn()
        {
            try
            {
                ShoppingCartBtn.Click();
            }
          
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return new CartPage(Driver);
        }

    }
}