using Allure.Net.Commons;
using Allure.Xunit.Attributes;
using SeleniumAutomation.Common;
using SeleniumAutomation.PageObjects;

namespace SeleniumAutomation.UITests;

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
                LoginPage.GoToLoginPage();
            }
        );

        Task("Enter valid credentials and click submit", () =>
            {
                LoginPage.EnterUsername("student");
                LoginPage.EnterPassword("Password123");
                LoginPage.ClickSubmit();
            }
        );

        Task("Assert url and login success text", () =>
            {
                Assert.Equal(
                    "https://practicetestautomation.com/logged-in-successfully/",
                    Driver.Url
                );
                Assert.Equal("Logged In Successfully", LoginPage.GetSuccessMessage());
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
                LoginPage.GoToLoginPage();
            }
        );

        Task("Enter invalid credentials and click submit", () =>
            {
                LoginPage.EnterUsername("student");
                LoginPage.EnterPassword("invalidPassword123");
                LoginPage.ClickSubmit();
            }
        );

        Task("Assert url and login failure text", () =>
            {
                Assert.Equal("https://practicetestautomation.com/practice-test-login/", Driver.Url);
                Assert.Equal("Your password is invalid!", LoginPage.GetErrorMessage());
            }
        );
    }
}
