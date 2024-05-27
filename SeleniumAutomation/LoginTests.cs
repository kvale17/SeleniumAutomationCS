using System;
using System.ComponentModel;
using Allure.Net.Commons;
using Allure.Xunit.Attributes;
using Allure.Xunit.Attributes.Steps;
using SeleniumCSAutomation.Common;
using Xunit.Abstractions;

namespace SeleniumCSAutomation
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
            AllureApi.Step(
                "Go to login page",
                () =>
                {
                    Driver
                        .Navigate()
                        .GoToUrl("https://practicetestautomation.com/practice-test-login/");
                }
            );

            AllureApi.Step(
                "Enter valid credentials and click submit",
                () =>
                {
                    UIMethods.Type("#username", "student");
                    UIMethods.Type("#password", "Password123");

                    UIMethods.Click("#submit");
                }
            );

            AllureApi.Step(
                "Assert url and login success text",
                () =>
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
            AllureApi.Step(
                "Go to login page",
                () =>
                {
                    Driver
                        .Navigate()
                        .GoToUrl("https://practicetestautomation.com/practice-test-login/");
                }
            );

            AllureApi.Step(
                "Enter invalid credentials and click submit",
                () =>
                {
                    UIMethods.Type("#username", "student");
                    UIMethods.Type("#password", "invalidPassword123");

                    UIMethods.Click("#submit");
                }
            );

            AllureApi.Step(
                "Assert url and login failure text",
                () =>
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
