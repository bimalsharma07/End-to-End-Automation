using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemoAutomation.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        
        private readonly By firstNameInput = By.Id("first-name");
        private readonly By lastNameInput = By.Id("last-name");
        private readonly By postalCodeInput = By.Id("postal-code");
        private readonly By continueButton = By.Id("continue");
        private readonly By finishButton = By.Id("finish");
        private readonly By completionMessage = By.ClassName("complete-header");

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void FillCheckoutInformation(string firstName, string lastName, string postalCode)
        {
            wait.Until(d => d.FindElement(firstNameInput)).SendKeys(firstName);
            driver.FindElement(lastNameInput).SendKeys(lastName);
            driver.FindElement(postalCodeInput).SendKeys(postalCode);
            driver.FindElement(continueButton).Click();
        }

        public void CompleteCheckout()
        {
            wait.Until(d => d.FindElement(finishButton)).Click();
        }

        public bool IsOrderCompleted()
        {
            var message = wait.Until(d => d.FindElement(completionMessage));
            return message.Text.Contains("Thank you for your order");
        }
    }
}
