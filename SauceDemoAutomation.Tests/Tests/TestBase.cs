using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoAutomation.Drivers;
using System;

namespace SauceDemoAutomation.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public virtual void SetUp()
        {
            try
            {
               
                driver = WebDriverFactory.CreateDriver();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                
                
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Setup failed: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
            try
            {
                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"TearDown error: {ex.Message}");
            }
        }
    }
}
