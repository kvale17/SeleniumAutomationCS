using System.Threading;
using OpenQA.Selenium;

namespace SeleniumCSAutomation.Common
{
    public static class WebDriverContext
    {
        private static readonly AsyncLocal<IWebDriver> _currentDriver = new();

        public static IWebDriver CurrentDriver
        {
            get => _currentDriver.Value!;
            set => _currentDriver.Value = value;
        }
    }
}
