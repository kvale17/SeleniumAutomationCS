﻿using OpenQA.Selenium;

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

        public static void Click(IWebElement element)
        {
            element.Click();
        }

        public static void Click(IWebElement contextElement, By locator)
        {
            contextElement.FindElement(locator).Click();
        }

        public static void Click(Func<string, By> locator, string parameter)
        {
            Driver.FindElement(locator(parameter)).Click();
        }

        public static string GetText(By locator)
        {
            return Driver.FindElement(locator).Text;
        }

        public static string GetText(IWebElement element)
        {
            return element.Text;
        }
    }
}
