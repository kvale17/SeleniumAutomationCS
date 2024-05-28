using System;
using Allure.Net.Commons;
using Allure.Xunit.Attributes;
using OpenQA.Selenium;
using SeleniumAutomation.Common;
using Xunit;
using Xunit.Abstractions;

namespace SeleniumAutomation.UITests
{
    public class LoginTests : BaseTest
    {
        public LoginTests(ITestOutputHelper output)
            : base(output) { }

        [Fact]
        [AllureDescription("Login with valid credentials and verify successful login")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kevin Valencia")]
        public void CanLoginWithValidCredentials()
        {
            Task("Go to login page", () =>
                {
                    Driver
                        .Navigate()
                        .GoToUrl("https://practicetestautomation.com/practice-test-login/");
                }
            );

            Task("Enter valid credentials and click submit", () =>
                {
                    UIMethods.Type("#username", "student");
                    UIMethods.Type("#password", "Password123");
                    UIMethods.Click("#submit");
                }
            );

            Task("Assert url and login success text", () =>
                {
                    Assert.Equal(
                        "https://practicetestautomation.com/logged-in-successfully/",
                        Driver.Url
                    );
                    UIMethods.AssertText(".post-title", "Logged In Successfully");
                }
            );
        }

        [Fact]
        [AllureDescription("Login with invalid credentials and verify failed login")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kevin Valencia")]
        public void CannotLoginWithInvalidValidCredentials()
        {
            Task("Go to login page", () =>
                {
                    Driver
                        .Navigate()
                        .GoToUrl("https://practicetestautomation.com/practice-test-login/");
                }
            );

            Task("Enter invalid credentials and click submit", () =>
                {
                    UIMethods.Type("#username", "student");
                    UIMethods.Type("#password", "invalidPassword123");
                    UIMethods.Click("#submit");
                }
            );

            Task("Assert url and login failure text", () =>
                {
                    Assert.Equal(
                        "https://practicetestautomation.com/practice-test-login/",
                        Driver.Url
                    );
                    UIMethods.AssertText("#error.show", "Your password is invalid!");
                }
            );
        }
    }
}
