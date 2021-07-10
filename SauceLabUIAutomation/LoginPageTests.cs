using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SauceLabUIAutomation
{
    [TestFixture]
    [Category("Login Page Tests")]
    public class LoginPageTests : BaseTests
    {
        //LoginPageTest Class Properties


        //Test Cases
        [Description("Login with Standard User - Correct Username/Password")]
        [Property("Author", "Jason Jayakumar")]
        [Test]
        public void ValidCredentialsLoginTest()
        {
            test = extent.CreateTest("Standard User Login").Info("Start of Test");
            var loginPage = new LoginPage(Driver);
            loginPage.GoTo();
            test.Log(Status.Info,"Navigate to Sauce Demo Login Page");
            loginPage.EnterCredsAndLogin("standard_user", "secret_sauce");
            test.Log(Status.Info, "Entered Username:standard_user and Password:secret_sauce");
            HomePage homePage = loginPage.IsCredentialsValid();
            Assert.That(homePage, Is.Not.EqualTo(null));
            test.Log(Status.Pass, "Login Successful");

        }
    }
}