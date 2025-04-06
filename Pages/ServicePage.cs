using OpenQA.Selenium;
using System;
using BDD.Utilities;

namespace BDD.Pages
{
    public class ServicePage : BasePage
    {
        private readonly By _titleSpan = By.CssSelector("span.museo-sans-500.gradient-text, span.rte-text-gradient.gradient-text");
        //XPath is used to locate the "Our Related Expertise" section instead of indexed CSS selector
        private readonly By _relatedExpertiseSection = By.XPath("//span[@class='museo-sans-light' and contains(text(), 'Offerings')]");

        public ServicePage(IWebDriver driver) : base(driver)
        {
        }

        public bool ValidateServiceTitle(string expectedService)
        {
            //get the page title and verify it matches the expected service name
            var titleElement = WaitAndFindElement(_titleSpan);
            var pageTitle = titleElement.Text.Trim();

            Logger.LogInfo($"Page title found: {pageTitle}");
            return pageTitle.Equals(expectedService, StringComparison.OrdinalIgnoreCase);
        }

        public bool IsRelatedExpertiseSectionDisplayed()
        {
            var section = WaitAndFindElement(_relatedExpertiseSection);
            ScrollToElement(section);
            Logger.LogInfo("'Our Related Expertise' section is displayed.");
            return section.Displayed;
        }
    }
}
