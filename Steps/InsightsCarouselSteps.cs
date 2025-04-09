using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using BDD.Pages;
using BDD.Hooks;

namespace BDD.Steps
{
    [Binding]
    public class InsightsCarouselSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private InsightsPage _insightsPage;
        private ArticlePage _articlePage;
        private string _carouselTitle; 
        private string _articlePageTitle;

        public InsightsCarouselSteps(LifecycleHooks hooks)
        {
            _driver = hooks.GetDriver();         
            _homePage = new HomePage(_driver);  
        }

        [When(@"I navigate to the Insights page")]
        public void WhenINavigateToTheInsightsPage()
        {
            _insightsPage = _homePage.NavigateToInsights(); 
        }

        [When(@"I swipe the carousel to the next item")]
        public void WhenISwipeTheCarouselToTheNextItem()
        {
            _insightsPage.SwipeCarouselNext(); 
        }

        [When(@"I get the carousel article title")]
        public void WhenIGetTheCarouselArticleTitle()
        {
            string carouselTitle = _insightsPage.GetCarouselArticleTitle();
            Assert.That(carouselTitle, Is.Not.Empty, "Carousel title should not be empty");
        }

        [When(@"I click the ""Read More"" button")]
        public void WhenIClickTheReadMoreButton()
        {
            var readMoreButton = _insightsPage.GetReadMoreButton(); 
            _articlePage = _insightsPage.ClickReadMoreButton(readMoreButton); 
        }

        [When(@"I get the article page title")]
        public void WhenIGetTheArticlePageTitle()
        {
            string articlePageTitle = _articlePage.GetArticleTitle();
            Assert.That(articlePageTitle, Is.Not.Empty, "Article page title should not be empty");
        }

        [Then(@"the carousel article title should match the article page title")]
        public void ThenTheCarouselArticleTitleShouldMatchTheArticlePageTitle()
        {
            Assert.That(_articlePageTitle, Is.EqualTo(_carouselTitle),
                $"Article title '{_articlePageTitle}' does not match carousel title '{_carouselTitle}'");
        }
    }
}
