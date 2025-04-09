using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SeleniumExtras.WaitHelpers;

namespace BDD.Utilities
{
    public static class WaitHelper
    {
        public static IWebElement WaitUntilElementVisible(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Element not visible: {locator}");
                throw new NoSuchElementException($"Element not visible: {locator}", ex);
            }
        }

        public static IReadOnlyCollection<IWebElement> WaitUntilElementsPresent(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Elements not present: {locator}");
                throw new NoSuchElementException($"Elements not present: {locator}", ex);
            }
        }

        public static bool WaitUntilPageLoaded(this IWebDriver driver, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                return wait.Until(d => ((IJavaScriptExecutor)d)
                    .ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception ex)
            {
                Logger.LogError("Page load timeout");
                throw new WebDriverTimeoutException("Page load timeout", ex);
            }
        }
    }
}
