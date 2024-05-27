using System.ComponentModel;
using Allure.Net.Commons;
using Allure.Xunit.Attributes;
using Allure.Xunit.Attributes.Steps;
using SeleniumCSAutomation.Common;

namespace SeleniumCSAutomation
{
    public class LoginTests : BaseTest
    {
        [Fact]
        [AllureDescription("Login with valid credentials and verify successful login")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Kevin Valencia")]
        public void LoginWithValidCredentials()
        {
            Driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

            UIMethods.Type("#username", "student");
            UIMethods.Type("#password", "Password123");

            UIMethods.Click("#submit");

            Assert.Equal("https://practicetestautomation.com/logged-in-successfully/", Driver.Url);

            UIMethods.AssertText(".post-title", "Logged In Successfully");
        }
    }
}
