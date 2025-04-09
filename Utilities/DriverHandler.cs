using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace BDD.Utilities
{
    public static class DriverHandler
    {
        private static IWebDriver _driver;

        public static IWebDriver InitializeDriver()
        {
            var options = ConfigureChromeOptions();
            _driver = new ChromeDriver(options);
            return _driver;
        }
        private static ChromeOptions ConfigureChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            return options;
        }
        //removed QuitDriver() here, as I have _driver.Dispose(); in [AfterScenario] in hooks
    }
}
