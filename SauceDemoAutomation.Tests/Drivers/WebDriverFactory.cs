using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoAutomation.Drivers
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();

            // Start in headed mode (normal UI)
            options.AddArgument("--start-maximized");

            // Disable Chrome's password manager popup
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            // Optional: Disable "Chrome is being controlled..." banner
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);

            // Launch the driver
            return new ChromeDriver(options);
        }
    }
}
