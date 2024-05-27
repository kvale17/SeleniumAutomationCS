using System;
using Allure.Net.Commons;
using Allure.Xunit.Attributes.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation.Common;
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
                string screenshotFilePath = TestUtils.TakeScreenshot(Driver, "test");

                AllureApi.AddAttachment(
                    "testTitle.png",
                    "image/png",
                    File.ReadAllBytes(screenshotFilePath)
                );

                Driver.Quit();
                Driver.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
