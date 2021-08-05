using AventStack.ExtentReports;
using NUnit.Framework;

namespace SauceLabUIAutomation
{
    public class CheckOutTests : BaseHomePageTests
    {
        protected CartPage CartPage { get; set; }

        [Description("CheckoutPage_SingleItem")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void CheckOutSingleItemTest()
        {
            test = extent.CreateTest("Hamburger Menu - Logout").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.AddItemToCart(0);
            test.Log(Status.Info, "Added item to cart");
            CartPage = HomePage.ClickCartBtn();
            test.Log(Status.Info, "Cart Button Clicked");
            CartPage.ClickCheckOutBtn();
            test.Log(Status.Info, "Checkout Button Clicked");


        }
    }
}
