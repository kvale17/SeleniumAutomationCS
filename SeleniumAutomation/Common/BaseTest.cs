using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumCSAutomation.Common
{
    public class BaseTest : IDisposable
    {
        internal static IWebDriver Driver { get; private set; } = null!;

        //Setup
        public BaseTest()
        {
            Driver = new ChromeDriver();
        }

        //Teardown
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
