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
        private IList<IWebElement> ItemPrices => Driver.FindElements(By.ClassName("Inventory_item_price"));
        public HomePage(IWebDriver driver) : base(driver)
        {}

        public void SelectDropdownOption(int index)
        {
            SelectElement select = new SelectElement(FilterDropDown);
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

        public bool IsItemsOrderedbyPrice()
        {
            if (ItemNames[0].GetAttribute("innerText").Equals("$7.99") && ItemNames[ItemNames.Count - 1].GetAttribute("innerText").Equals("$49.99")) { 
                return true;
            }
            else return false;
        }

    }
}