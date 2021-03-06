using AventStack.ExtentReports;
using NUnit.Framework;
using SauceLabUIAutomation.BasePages;
using SauceLabUIAutomation.PageObjects;
using System.Threading;

namespace SauceLabUIAutomation.TestPages
{
    public class CompletePurchaseTests : BaseHomePageTests
    {
        private CartPage CartPage { get; set; }
        private CheckOutPage CheckOutPage { get; set; }
        private OverViewPage OverViewPage { get; set; }
        private OrderCompletePage OrderCompletePage { get; set; }

        [Test]
        [Description("CheckoutPage_SingleItem_HappyPath")]
        [Property("Author", "Jason Jayakumar")]
        public void CheckOutSingleItemTest()
        {
            test = extent.CreateTest("Hamburger Menu - Logout").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.AddItemToCart(0);
            test.Log(Status.Info, "Added item to cart");
            CartPage = HomePage.ClickCartBtn();
            Assert.That(CartPage.GetType(), Is.EqualTo(typeof(CartPage)));
            test.Log(Status.Pass, "At Cart Page");
            CheckOutPage = CartPage.ClickCheckOutBtn();
            Assert.That(CheckOutPage.GetType(), Is.EqualTo(typeof(CheckOutPage)));
            test.Log(Status.Pass, "At Checkout Page.");
            CheckOutPage.EnterCheckOutInfo("Jay", "Jayakumar", "111 111");
            OverViewPage = CheckOutPage.ClickContinue();
            Assert.That(OverViewPage.GetType(), Is.EqualTo(typeof(OverViewPage)));
            test.Log(Status.Pass, "At OverView Page. ");
            Assert.That(OverViewPage.GetCheckOutItem(0), Is.EqualTo("Sauce Labs Backpack"));
            test.Log(Status.Pass, "Correct Item is ready for Checkout ");
            OrderCompletePage = OverViewPage.Finish();
            Assert.That(OrderCompletePage.IsCheckOutComplete());
            test.Log(Status.Pass, "Purchase has successfully been completed");

        }

        [Test]
        [Description("CheckoutPage_MultipleItems_HappyPath")]
        [Property("Author", "Jason Jayakumar")]
        public void CheckOutMultipleItemsTest()
        {
            test = extent.CreateTest("Hamburger Menu - Logout").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.AddItemToCart(0);
            HomePage.AddItemToCart(1);
            HomePage.AddItemToCart(2);
            test.Log(Status.Info, "Added item to cart");
            CartPage = HomePage.ClickCartBtn();
            Assert.That(CartPage.GetType(), Is.EqualTo(typeof(CartPage)));
            test.Log(Status.Pass, "At Cart Page");
            CheckOutPage = CartPage.ClickCheckOutBtn();
            Assert.That(CheckOutPage.GetType(), Is.EqualTo(typeof(CheckOutPage)));
            test.Log(Status.Pass, "At Checkout Page.");
            CheckOutPage.EnterCheckOutInfo("Jay", "Jayakumar", "111 111");
            OverViewPage = CheckOutPage.ClickContinue();
            Assert.That(OverViewPage.GetType(), Is.EqualTo(typeof(OverViewPage)));
            test.Log(Status.Pass, "At OverView Page. ");
            Assert.That(OverViewPage.GetCheckOutItem(0), Is.EqualTo("Sauce Labs Backpack"));
            Assert.That(OverViewPage.GetCheckOutItem(1), Is.EqualTo("Sauce Labs Bike Light"));
            Assert.That(OverViewPage.GetCheckOutItem(2), Is.EqualTo("Sauce Labs Bolt T-Shirt"));
            test.Log(Status.Pass, "Correct Item is ready for Checkout ");
            OrderCompletePage = OverViewPage.Finish();
            Assert.That(OrderCompletePage.IsCheckOutComplete());
            test.Log(Status.Pass, "Purchase has successfully been completed");

        }

    }
}
