using System;
using Allure.Net.Commons;
using Allure.Xunit.Attributes.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumAutomation.Common
{
    public class BaseTest : XunitContextBase
    {
        protected static IWebDriver Driver
        {
            get => WebDriverContext.CurrentDriver;
            private set => WebDriverContext.CurrentDriver = value;
        }

        private readonly ITestOutputHelper output;

        [AllureBefore("Setup")]
        public BaseTest(ITestOutputHelper output)
            : base(output)
        {
            this.output = output;
            Driver = new ChromeDriver();
        }

        [AllureAfter("Teardown")]
        public override void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        protected static void Step(string stepName, Action action)
        {
            AllureApi.Step(
                stepName,
                () =>
                {
                    try
                    {
                        action();
                    }
                    catch (Exception ex)
                    {
                        string testName = (XunitContext.Context.Test.DisplayName);

                        string screenshotFilePath = TestUtils.TakeScreenshot(Driver, testName);

                        AllureApi.AddAttachment(
                            $"{testName}.png",
                            "image/png",
                            File.ReadAllBytes(screenshotFilePath)
                        );

                        throw new Exception("Step failed {" + ex + "}");
                    }
                }
            );
        }
    }
}
