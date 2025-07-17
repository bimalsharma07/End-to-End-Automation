using OpenQA.Selenium;

namespace SauceDemoAutomation.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver driver;

        // Locators
        private readonly By addToCartButtons = By.CssSelector("[data-test^='add-to-cart']");
        private readonly By cartLink = By.CssSelector(".shopping_cart_link");
        
        // Specific product locators
        private readonly By firstProductButton = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By secondProductButton = By.Id("add-to-cart-sauce-labs-fleece-jacket");

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddSpecificProducts()
        {
            driver.FindElement(firstProductButton).Click();
            driver.FindElement(secondProductButton).Click();
            GoToCart();
        }

        public void AddAllProductsAndGoToCart()
        {
            var buttons = driver.FindElements(addToCartButtons);
            foreach (var button in buttons)
            {
                button.Click();
                // Adding a small wait to make the test more visible
                System.Threading.Thread.Sleep(500);
            }
            GoToCart();
        }

        public void GoToCart()
        {
            driver.FindElement(cartLink).Click();
        }
    }
}

