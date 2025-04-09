using OpenQA.Selenium;
using System;
using BDD.Utilities;

namespace BDD.Pages
{
    public class ServicesPage : BasePage
    {
        private readonly By _ourCoreServicesHeader = By.XPath("//span[@class='museo-sans-light' and contains(text(), 'Our Core Services')]");
        //indexed CSS selector works for the first element only, 'Strategy'
        private readonly By _strategyButton = By.XPath("//span[@class='button__content button__content--desktop' and normalize-space()='STRATEGY']");
        private readonly By _cybersecurityButton = By.XPath("//span[@class='button__content button__content--desktop' and normalize-space()='CYBERSECURITY']");

        public ServicesPage(IWebDriver driver) : base(driver)
        {
        }

        public ServicePage SelectServiceCategory(string service)
        {
            //'Our Core Services' section is visible
            var coreServicesHeader = WaitAndFindElement(_ourCoreServicesHeader);

            //switch-case for easier extension with more services
            By serviceButtonLocator;
            switch (service.ToLower())
            {
                case "strategy":
                    serviceButtonLocator = _strategyButton;
                    Logger.LogInfo("Selected 'Strategy' from the Our Core Services section.");
                    break;

                case "cybersecurity":
                    serviceButtonLocator = _cybersecurityButton;
                    Logger.LogInfo("Selected 'Cybersecurity' from the Our Core Services section.");
                    break;

                default:
                    throw new Exception($"Invalid service category: {service}");
            }

            //click the selected button
            var serviceButton = WaitAndFindElement(serviceButtonLocator);
            ClickElement(serviceButton);
            return new ServicePage(Driver); //new ServicePage instance
        }
    }
}