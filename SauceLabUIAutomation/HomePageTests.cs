using AventStack.ExtentReports;
using NUnit.Framework;


namespace SauceLabUIAutomation
{
    [TestFixture]
    [Category("Home Page Tests")]
    public class HomePageTests : BaseHomePageTests
    {
        [Description("HomePage_FilterDropDown_Name(A-Z)")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void FilterNamesFromAToZTest()
        {
            test = extent.CreateTest("Filter DropDown A-Z Option").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.SelectDropdownOption(0);
            test.Log(Status.Info, "First Dropdown option selected (Name A-Z)");
            Assert.That(HomePage.IsItemsOrderedAlphabetically());
            test.Log(Status.Pass, "Items are Ordered From A-Z Successfull");
        }

        [Description("HomePage_FilterDropDown_Name(Z-A)")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void FilterNamesFromZToATest()
        {
            test = extent.CreateTest("Filter DropDown Z-A Option").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.SelectDropdownOption(1);
            test.Log(Status.Info, "Second Dropdown option selected (Name Z-A)");
            Assert.That(!HomePage.IsItemsOrderedAlphabetically());
            test.Log(Status.Pass, "Items are Ordered from Z-A Successfully");
        }

        [Description("HomePage_FilterDropDown_Price(Low To High)")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void FilterPriceLowToHighTest()
        {
            test = extent.CreateTest("Filter DropDown Price (Low to High) Option").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.SelectDropdownOption(2);
            test.Log(Status.Info, "Third Dropdown option selected (Price Low to Hig)");
            Assert.That(HomePage.IsItemsOrderedbyPriceLowToHigh());
            test.Log(Status.Pass, "Items are Ordered price(Low to high)");
        }

        [Description("HomePage_FilterDropDown_Price(High to Low")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void FilterPriceHighToLowTest()
        {
            test = extent.CreateTest("Filter DropDown Price(High To Low) Option").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.SelectDropdownOption(3);
            test.Log(Status.Info, "Third Dropdown option selected (Price Low to High");
            Assert.That(!HomePage.IsItemsOrderedbyPriceLowToHigh());
            test.Log(Status.Pass, "Items are Ordered price(High to Low)");
        }

        [Description("HomePage_HamburgerMenu_About")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void AboutPageTest()
        {
            test = extent.CreateTest("Hamburger Menu - About Page").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.ClickHamburgerMenu();
            test.Log(Status.Info, "Hamburger Menu clicked");
            Assert.That(HomePage.SelectAbout(), Is.EqualTo ("Cross Browser Testing, Selenium Testing, Mobile Testing | Sauce Labs"));
            test.Log(Status.Pass, "Navigated to About page");
        }

        [Description("HomePage_HamburgerMenu_Logout")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void LogoutTest()
        {
            test = extent.CreateTest("Hamburger Menu - Logout").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.ClickHamburgerMenu();
            test.Log(Status.Info, "Hamburger Menu clicked");
            Assert.That(HomePage.SelectLogout(), Is.EqualTo("Swag Labs"));
            test.Log(Status.Pass, "Successfully Logged out");
        }

        //Will always fail as there is a bug with 1 of the buttons, when app state is being reset this button does not reset its state.
        [Description("HomePage_HamburgerMenu_ResetAppState")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void ResetAppStateTest()
        {
            test = extent.CreateTest("Hamburger Menu - Logout").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage.AddItemToCart(0);
            test.Log(Status.Info, "First Item is added to cart");
            HomePage.ClickHamburgerMenu();
            test.Log(Status.Info, "Hamburger Menu clicked");
            Assert.That(HomePage.ResetAppState());
            test.Log(Status.Pass, "Default App State restored");
        }
    }
}
