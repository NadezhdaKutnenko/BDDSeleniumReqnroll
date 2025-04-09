using OpenQA.Selenium;
using BDD.Utilities;

namespace BDD.Pages
{
    public class JobDetailsPage : BasePage
    {
        private readonly By _jobDescription = By.XPath("//div[contains(@class, 'vacancy-description')] | //div[contains(@class, 'description')]");

        public JobDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool ValidateJobDescription(string keyword)
        {
            var descriptionElement = WaitAndFindElement(_jobDescription);
            var descriptionText = descriptionElement.Text.ToLower();
            var keywordExists = descriptionText.Contains(keyword.ToLower());

            if (keywordExists)
                Logger.LogInfo($"Successfully validated keyword '{keyword}' in job description");
            else
                Logger.LogError($"Keyword '{keyword}' not found in job description");

            return keywordExists;
        }
    }
}
