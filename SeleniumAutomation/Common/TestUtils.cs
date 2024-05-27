using System;
using System.IO;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumAutomation.Common
{
    public static class TestUtils
    {
        public static string TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            string screenshotFilePath = Path.Combine(
                Path.GetFullPath(@"..\..\..\"),
                "screenshots",
                $"{screenshotName}_{DateTime.Now:yyyyMMdd_HHmmss}.png"
            );

            screenshot.SaveAsFile(screenshotFilePath);
            return screenshotFilePath;
        }
    }
}
