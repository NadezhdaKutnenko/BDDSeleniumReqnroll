using BDD.Utilities;
using OpenQA.Selenium;
using Reqnroll;

namespace BDD.Hooks
{
    [Binding]
    public class LifecycleHooks
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = DriverHandler.InitializeDriver();
            Logger.LogInfo("Driver initialized");
            Logger.LogInfo($"WebDriver object inside BeforeScenario: {_driver != null}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //method is part of .NET, IDisposable; internally call .Quit() and cleaning up resources
            _driver.Dispose();
            Logger.LogInfo("Driver quit and disposed");
        }

        public IWebDriver GetDriver() => _driver; //expose the driver to step definitions
    }
}
