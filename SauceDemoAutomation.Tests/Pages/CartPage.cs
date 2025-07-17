using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemoAutomation.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // Locators
        private readonly By checkoutButton = By.Id("checkout");
        private readonly By cartTitle = By.ClassName("title");
        private readonly By cartItems = By.ClassName("cart_item");

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool IsCartPageDisplayed()
        {
            var title = wait.Until(d => d.FindElement(cartTitle));
            return title.Text.Equals("Your Cart");
        }

        public int GetCartItemCount()
        {
            return driver.FindElements(cartItems).Count;
        }

        public void ProceedToCheckout()
        {
            wait.Until(d => d.FindElement(checkoutButton)).Click();
        }
    }
}
