using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoAutomation.Pages;
using System;

namespace SauceDemoAutomation.Tests
{
    [TestFixture]
    [Category("EndToEnd")]
    public class SwagLabsEndToEndTests : TestBase
    {
        private LoginPage loginPage;
        private InventoryPage inventoryPage;
        private CartPage cartPage;
        private CheckoutPage checkoutPage;

        [SetUp]
        public override void SetUp()
        {
            try
            {
                
                base.SetUp();
                
                
                loginPage = new LoginPage(driver);
                inventoryPage = new InventoryPage(driver);
                cartPage = new CartPage(driver);
                checkoutPage = new CheckoutPage(driver);
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Setup failed: {ex.Message}");
                throw;
            }
        }

        [Test]
        [Description("Complete end-to-end purchase flow")]
        public void Complete_Purchase_Flow()
        {
            try
            {
                // Step 1: Login
                TestContext.Progress.WriteLine("Step 1: Logging in...");
                Assert.That(driver.Title, Is.EqualTo("Swag Labs"), "Login page not loaded properly");
                loginPage.Login("standard_user", "secret_sauce");
                Assert.That(driver.Url, Does.Contain("inventory"), "Login was not successful");

                // Step 2: Add products to cart
                TestContext.Progress.WriteLine("Step 2: Adding products to cart...");
                inventoryPage.AddSpecificProducts();
                Assert.That(driver.Url, Does.Contain("cart"), "Did not navigate to cart page");

                // Step 3: Verify cart and proceed to checkout
                TestContext.Progress.WriteLine("Step 3: Verifying cart and proceeding to checkout...");
                Assert.That(cartPage.IsCartPageDisplayed(), Is.True, "Cart page is not displayed");
                Assert.That(cartPage.GetCartItemCount(), Is.EqualTo(2), "Cart does not contain expected number of items");
                cartPage.ProceedToCheckout();

                // Step 4: Complete checkout process
                TestContext.Progress.WriteLine("Step 4: Completing checkout process...");
                checkoutPage.FillCheckoutInformation("John", "Doe", "12345");
                checkoutPage.CompleteCheckout();

                // Step 5: Verify order completion
                TestContext.Progress.WriteLine("Step 5: Verifying order completion...");
                Assert.That(checkoutPage.IsOrderCompleted(), Is.True, "Order completion message not displayed");
                
                TestContext.Progress.WriteLine("End-to-end test completed successfully!");
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"End-to-end test failed: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
