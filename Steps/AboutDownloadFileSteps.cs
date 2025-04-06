using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using BDD.Pages;
using BDD.Hooks;

namespace BDD.Steps
{
    [Binding]
    public class AboutDownloadFileSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private AboutPage _aboutPage;

        public AboutDownloadFileSteps(LifecycleHooks hooks)
        {
            _driver = hooks.GetDriver();
            _homePage = new HomePage(_driver);
        }

        [When(@"I navigate to the About page")]
        public void WhenINavigateToTheAboutPage()
        {
            _aboutPage = _homePage.NavigateToAbout(); //navigation logic remains with HomePage
        }

        [When(@"I download the ""(.*)"" file")]
        public void WhenIDownloadTheFile(string fileName)
        {
            _aboutPage.ScrollToGlanceSection(); //section is in view
            _aboutPage.DownloadFile(fileName); //initiates the download
        }

        [Then(@"the file ""(.*)"" is downloaded successfully")]
        public void ThenTheFileIsDownloadedSuccessfully(string expectedFileName)
        {
            var isFileDownloaded = _aboutPage.VerifyFileDownload(expectedFileName);
            Assert.That(isFileDownloaded, Is.True, $"File {expectedFileName} was not downloaded successfully.");
        }
    }
}
