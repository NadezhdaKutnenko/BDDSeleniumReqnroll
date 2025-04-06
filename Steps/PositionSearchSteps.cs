using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using BDD.Pages;
using BDD.Hooks;

namespace BDD.Steps
{
    [Binding]
    public class PositionSearchSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private CareersPage _careersPage;
        private JobDetailsPage _jobDetailsPage;

        public PositionSearchSteps(LifecycleHooks hooks)
        {
            _driver = hooks.GetDriver();
            _homePage = new HomePage(_driver);
        }

        [When(@"I navigate to the Careers page")]
        public void WhenINavigateToTheCareersPage()
        {
            _careersPage = _homePage.NavigateToCareers();
        }

        [When(@"I search for positions with ""(.*)"" in ""(.*)""")]
        public void WhenISearchForPositions(string keyword, string location)
        {
            _careersPage.FillSearchCriteria(keyword, location);
        }

        [Then(@"the job description of the last search result should contain ""(.*)""")]
        public void ThenTheJobDescriptionOfTheLastSearchResultShouldContain(string keyword)
        {
            _jobDetailsPage = _careersPage.SearchAndSelectLastPosition();
            Assert.That(_jobDetailsPage.ValidateJobDescription(keyword), Is.True,
                $"Job description does not contain the keyword: {keyword}");
        }
    }
}
