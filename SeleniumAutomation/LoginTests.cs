using System.ComponentModel;
using SeleniumCSAutomation.Common;

namespace SeleniumCSAutomation
{
    public class LoginTests : BaseTest
    {
        [Fact]
        [Trait("Category", "Smoke")]
        [DisplayName("Login with valid credentials and verify welcome message")]
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
