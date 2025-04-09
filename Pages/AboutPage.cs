using OpenQA.Selenium;
using BDD.Utilities;
using System.IO;
using System;

namespace BDD.Pages
{
    public class AboutPage : BasePage
    {
        private readonly By _glanceSection = By.XPath("//span[contains(text(),'EPAM at')]");
        private readonly By _downloadButton = By.XPath("//span[contains(@class,'button__content--desktop') and contains(text(),'DOWNLOAD')]");

        private readonly string _downloadPath;
        //set a default download path instead of FileHelper but it can be returned for file operations beyond AboutPage
        public AboutPage(IWebDriver driver) : base(driver)
        {
            _downloadPath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        }

        public void ScrollToGlanceSection()
        {
            var glanceSectionElement = WaitAndFindElement(_glanceSection);
            ScrollToElement(glanceSectionElement);
            Logger.LogInfo("Scrolled to EPAM at Glance section");
        }

        public void DownloadFile(string fileName)
        {
            var downloadButtonElement = WaitAndFindElement(_downloadButton);
            ClickElement(downloadButtonElement);
            Logger.LogInfo("Clicked download button");
        }

        public bool VerifyFileDownload(string fileName)
        {
            var filePath = Path.Combine(_downloadPath, fileName);
            var isFileDownloaded = WaitForDownload(filePath);

            if (isFileDownloaded)
                Logger.LogInfo($"File {fileName} downloaded successfully");
            else
                Logger.LogError($"File {fileName} was not downloaded successfully");

            return isFileDownloaded;
        }

        private bool WaitForDownload(string filePath, int timeoutInSeconds = EXTENDED_TIMEOUT)
        {
            var endTime = DateTime.Now.AddSeconds(timeoutInSeconds);
            while (DateTime.Now < endTime)
            {
                if (File.Exists(filePath))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
