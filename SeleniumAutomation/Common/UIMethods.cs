using OpenQA.Selenium;

namespace SeleniumAutomation.Common
{
    public static class UIMethods
    {
        private static IWebDriver Driver => WebDriverContext.CurrentDriver;

        public static void Type(By locator, string text)
        {
            Driver.FindElement(locator).SendKeys(text);
        }

        public static void Click(By locator)
        {
            Driver.FindElement(locator).Click();
        }

        public static string GetText(By locator)
        {
            return Driver.FindElement(locator).Text;
        }
    }
}
