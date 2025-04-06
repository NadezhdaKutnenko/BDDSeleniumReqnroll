using OpenQA.Selenium;
using BDD.Utilities;

namespace BDD.Pages
{
    public class ArticlePage : BasePage
    {
        private readonly By _articleTitle = By.CssSelector("div.text-ui-23 span.museo-sans-light");

        public ArticlePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetArticleTitle()
        {
            WaitForPageLoad();
            var titleElement = WaitAndFindElement(_articleTitle);
            var title = titleElement.Text.Trim();
            Logger.LogInfo($"Found article title: {title}");
            return title;
        }
    }
}
