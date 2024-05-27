using System;
using Allure.Xunit.Attributes.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumCSAutomation.Common
{
    public class BaseTest : IDisposable
    {
        protected static IWebDriver Driver
        {
            get => WebDriverContext.CurrentDriver;
            private set => WebDriverContext.CurrentDriver = value;
        }

        [AllureBefore("Setup")]
        public BaseTest()
        {
            Driver = new ChromeDriver();
        }

        [AllureAfter("Teardown")]
        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
