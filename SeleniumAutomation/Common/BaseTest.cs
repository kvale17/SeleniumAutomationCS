using System;
using Allure.Xunit.Attributes.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumCSAutomation.Common
{
    public class BaseTest : IDisposable
    {
        internal static IWebDriver Driver { get; private set; } = null!;

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
