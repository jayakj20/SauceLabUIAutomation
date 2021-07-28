using AventStack.ExtentReports;
using NUnit.Framework;

namespace SauceLabUIAutomation
{
    [TestFixture]
    [Category("Login Page Tests")]
    public class LoginPageTests : BaseTests
    { 
        /*
        Test Cases
        Only 4 login scenarios are coverred here. The reason being, there are only 4 unique paths on this website that
        that will show a different result and the 4 test cases below encapsulate all these results.
        */

        [Description("UserLogin_ValidUsername_ValidPassword")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void ValidUserLoginTest()
        {
            test = extent.CreateTest("Valid User Login").Info("Start of Test");
            test.Log(Status.Info,"Navigate to Sauce Demo Login Page");
            LoginPage.EnterCredsAndLogin("standard_user", "secret_sauce");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            Assert.That(LoginPage.LoginStatus(), Is.EqualTo("Passed, Successful Login"));
            test.Log(Status.Pass, "Login Successful");
        }

        [Description("UserLogin_NoUserName_NoPassword")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void EmptyCredentialsLoginTest()
        {
            test = extent.CreateTest("Login with nothing enterred in the password and username field").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            LoginPage.EnterCredsAndLogin("","");
            test.Log(Status.Info, "Entered blank for username and password");
            Assert.That (LoginPage.LoginStatus(), Is.EqualTo("Failed, Username and Password must be enterred"));
            test.Log(Status.Pass, "Login Failed, Correct Error message displayed");
        }

        [Description("UserLogin_ValidUsername_InvalidPassword")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void InvalidPasswordTest()
        {
            test = extent.CreateTest("Login with Invalid Password").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            LoginPage.EnterCredsAndLogin("standard_user", "failed");
            test.Log(Status.Info, "Entered Username:standard_user and Password:failed");
            Assert.That(LoginPage.LoginStatus(), Is.EqualTo("Failed, Username and Password do not Match"));
            test.Log(Status.Pass, "Login Failed, Correct Error message displayed");
        }

        [Description("UserLogin_EmptyPassword")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void EmptyPasswordTest()
        {
            test = extent.CreateTest("Login with Empty Password").Info("Start of Test");
            test.Log(Status.Info, "Navigate to Sauce Demo Login Page");
            LoginPage.EnterCredsAndLogin("standard_user", "");
            test.Log(Status.Info, "Entered Username:standard_user and Password:");
            Assert.That(LoginPage.LoginStatus(), Is.EqualTo("Failed, Password Required"));
            test.Log(Status.Pass, "Login Failed, Correct Error message displayed");
        }


    }
}