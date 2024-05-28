using OpenQA.Selenium;
using SeleniumAutomation.Common;

namespace SeleniumAutomation.PageObjects
{
    public static class LoginPage
    {
        private static readonly string url =
            "https://practicetestautomation.com/practice-test-login/";

        // Locators
        private static readonly By usernameField = By.CssSelector("#username");
        private static readonly By passwordField = By.CssSelector("#password");
        private static readonly By submitButton = By.CssSelector("#submit");
        private static readonly By successMessage = By.CssSelector(".post-title");
        private static readonly By errorMessage = By.CssSelector("#error.show");

        public static void GoToLoginPage()
        {
            WebDriverContext.CurrentDriver.Navigate().GoToUrl(url);
        }

        public static void EnterUsername(string username)
        {
            UIMethods.Type(usernameField, username);
        }

        public static void EnterPassword(string password)
        {
            UIMethods.Type(passwordField, password);
        }

        public static void ClickSubmit()
        {
            UIMethods.Click(submitButton);
        }

        public static string GetSuccessMessage()
        {
            return UIMethods.GetText(successMessage);
        }

        public static string GetErrorMessage()
        {
            return UIMethods.GetText(errorMessage);
        }
    }
}
