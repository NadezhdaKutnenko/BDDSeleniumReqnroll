using OpenQA.Selenium;
using System.Collections.Generic;
using BDD.Utilities;
using OpenQA.Selenium.Interactions;

namespace BDD.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected const int DEFAULT_TIMEOUT = 10;
        protected const int EXTENDED_TIMEOUT = 30;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        //use wait wrappers instead of direct calls in page objects to abstract all interaction-related waiting logic behind page methods
        protected IWebElement WaitAndFindElement(By locator, int timeoutInSeconds = DEFAULT_TIMEOUT)
        {
            return Driver.WaitUntilElementVisible(locator, timeoutInSeconds);
        }
        //removed WaitAndFindClickableElement
        protected IReadOnlyCollection<IWebElement> WaitAndFindElements(By locator, int timeoutInSeconds = DEFAULT_TIMEOUT)
        {
            return Driver.WaitUntilElementsPresent(locator, timeoutInSeconds);
        }

        protected void WaitForPageLoad()
        {
            Driver.WaitUntilPageLoaded();
        }

        protected void ScrollToElement(IWebElement element)
        {
            new Actions(Driver).ScrollToElement(element).Perform();
        }

        protected void ClickElement(IWebElement element)
        {
            element.Click();
        }
    }
}
