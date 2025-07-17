# End-to-End Automation

This repository provides an end-to-end automated testing framework for the [Swag Labs demo application](https://www.saucedemo.com/) using C#, Selenium WebDriver, and NUnit. It covers the entire user journey from login to order completion, ensuring the reliability of the application workflow.

## Features

- **Automated End-to-End Tests:** Simulates a real user’s journey including login, adding products to cart, checking out, and verifying order completion.
- **Page Object Model:** Structured codebase using the Page Object Model for maintainability and readability.
- **Reusable Components:** Common setup and teardown logic for tests, driver management, and wait strategies.
- **Extensible:** Easily add new scenarios or extend existing flows.

## Technologies Used

- **C#**
- **Selenium WebDriver**
- **NUnit**

## Test Flow Overview

The main end-to-end test performs the following:

1. **Login:** Authenticates using demo credentials.
2. **Product Selection:** Adds specific products to the cart.
3. **Cart Verification:** Ensures the correct items are in the cart.
4. **Checkout:** Completes the purchase process by filling in user information.
5. **Order Confirmation:** Verifies that order completion message is displayed.

## Repository Structure

```
SauceDemoAutomation.Tests/
├── Drivers/
│   └── WebDriverFactory.cs
├── Pages/
│   ├── LoginPage.cs
│   ├── InventoryPage.cs
│   ├── CartPage.cs
│   └── CheckoutPage.cs
└── Tests/
    ├── EndtoEnd.cs
    └── TestBase.cs
```

- **Drivers:** Contains logic for initializing and configuring the Selenium WebDriver.
- **Pages:** Implements the Page Object Model for each page used in the tests.
- **Tests:** Contains the end-to-end and base test classes.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Chrome browser](https://www.google.com/chrome/)
- [Chrome WebDriver](https://chromedriver.chromium.org/) (Ensure it matches your Chrome version)

---

**Author:** [bimalsharma07](https://github.com/bimalsharma07)
