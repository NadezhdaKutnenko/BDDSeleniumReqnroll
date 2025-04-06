using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using BDD.Pages;
using BDD.Hooks;
using BDD.Utilities;

namespace BDD.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly SearchResultsPage _searchResultsPage;

        //using dependency injection via the constructor
        public HomePageSteps(LifecycleHooks hooks)
        {
            _driver = hooks.GetDriver();
            _homePage = new HomePage(_driver);
        }

        [Given(@"I navigate to the EPAM website")]
        public void GivenINavigateToEPAMWebsite()
        {
            _homePage.OpenHomePage();
        }

        [Given(@"I accept cookies")]
        public void GivenIAcceptCookies()
        {
            _homePage.AcceptCookies();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string searchText)
        {
            _homePage.PerformSearch(searchText);
            Logger.LogInfo($"User performed a search for: {searchText}");
        }

        [Then(@"all search results should contain ""(.*)""")]
        public void ThenAllSearchResultsShouldContain(string searchText)
        {
            var searchResultsPage = new SearchResultsPage(_driver); //_driver is not null
            var failingLinks = searchResultsPage.GetFailingLinks(searchText);

            Assert.That(failingLinks, Is.Empty,
                $"{failingLinks.Count} links did not contain the search term: {searchText}");

            Logger.LogInfo("Search results contain the expected term.");
        }
    }
}
