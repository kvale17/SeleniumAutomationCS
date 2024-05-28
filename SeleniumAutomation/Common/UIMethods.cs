﻿using OpenQA.Selenium;

namespace SeleniumAutomation.Common
{
    public static class UIMethods
    {
        private static IWebDriver Driver => WebDriverContext.CurrentDriver;

        public static void AssertText(string cssPath, string expectedText)
        {
            string elementText = Driver.FindElement(By.CssSelector(cssPath)).Text;

            Assert.Equal(elementText, expectedText);
        }

        public static void Click(string cssPath)
        {
            Driver.FindElement(By.CssSelector(cssPath)).Click();
        }

        public static void Type(string cssPath, string text)
        {
            IWebElement element = Driver.FindElement(By.CssSelector(cssPath));
            element.Clear();
            element.SendKeys(text);
        }
    }
}
