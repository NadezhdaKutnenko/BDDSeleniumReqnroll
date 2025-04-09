using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using BDD.Pages;
using BDD.Hooks;

namespace BDD.Steps
{
    [Binding]
    public class ServicesNavigationSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private ServicesPage _servicesPage;
        private ServicePage _servicePage;

        public ServicesNavigationSteps(LifecycleHooks hooks)
        {
            _driver = hooks.GetDriver();         
            _homePage = new HomePage(_driver);  
        }

        [When(@"I navigate to the Services page")]
        public void WhenINavigateToTheServicesPage()
        {
            _servicesPage = _homePage.NavigateToServices();
        }

        [When(@"I select the ""(.*)"" from the ""Our Core Services"" section")]
        public void WhenISelectTheServiceFromTheOurCoreServicesSection(string service)
        {
            //select a specific service category (parameterized)
            _servicePage = _servicesPage.SelectServiceCategory(service);
        }

        [Then(@"the page title should display the ""(.*)"" service")]
        public void ThenThePageTitleShouldDisplayTheService(string service)
        {
            Assert.That(_servicePage.ValidateServiceTitle(service), Is.True,
                $"The page title does not match the expected service: {service}");
        }

        [Then(@"the ""Our Related Expertise"" section should be displayed")]
        public void ThenTheOurRelatedExpertiseSectionShouldBeDisplayed()
        {
            Assert.That(_servicePage.IsRelatedExpertiseSectionDisplayed(), Is.True,
                "The 'Our Related Expertise' section is not displayed.");
        }
    }
}
