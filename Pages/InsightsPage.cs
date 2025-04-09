using OpenQA.Selenium;
using BDD.Utilities;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace BDD.Pages
{
    public class InsightsPage : BasePage
    {
        private readonly By _carouselNextButton = By.CssSelector("button.owl-next");
        private readonly By _activeSlide = By.CssSelector("div.owl-item.active");
        private readonly By _titleContainer = By.CssSelector("div.text-ui-23");
        private readonly By _readMoreButton = By.CssSelector("a.link-with-bottom-arrow, a.link-with-right-arrow");
        private readonly WebDriverWait wait;
        private const int DEFAULT_SWIPE_COUNT = 2;

        public InsightsPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DEFAULT_TIMEOUT));
        }

        public void SwipeCarouselNext()
        {
            var nextButton = wait.Until(driver => driver.FindElement(_carouselNextButton));

            for (int i = 0; i < DEFAULT_SWIPE_COUNT; i++) 
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", nextButton);
                Logger.LogInfo($"Swiped carousel to next item. Swipe count: {i + 1}");
            }
        }

        public string GetCarouselArticleTitle()
        {
            var slide = WaitAndFindElement(_activeSlide);
            var titleElement = slide.FindElement(_titleContainer);
            string carouselTitle = titleElement.Text.Trim();

            Assert.That(carouselTitle, Is.Not.Empty, "Carousel title should not be empty");
            Logger.LogInfo($"Found carousel article: {carouselTitle}");

            return carouselTitle;
        }

        public IWebElement GetReadMoreButton()
        {
            var slide = WaitAndFindElement(_activeSlide);
            return slide.FindElement(_readMoreButton);
        }

        public ArticlePage ClickReadMoreButton(IWebElement readMoreButton)
        {
            ScrollToElement(readMoreButton);
            ClickElement(readMoreButton);
            Logger.LogInfo("Clicked Read More button");
            return new ArticlePage(Driver);
        }
    }
}
