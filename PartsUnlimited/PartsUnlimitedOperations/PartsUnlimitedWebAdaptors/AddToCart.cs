using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using PartsUnlimitedOperations;
using PartsUnlimitedWebAdaptors;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PartsUnlimitedWebAdaptors
{
    /// <summary>
    /// Implementation of the IAddToCart interface that interacts with the web application 
    /// using Selenium WebDriver to add products to the cart and handle checkout.
    /// </summary>
    public class AddToCart : PartsUnlimitedCommon, IAddToCart, IDisposable
    {
        /// <summary>
        /// Default constructor to initialize the WebDriver.
        /// </summary>
        public AddToCart() : base() { }

        /// <summary>
        /// Constructor that accepts a WebDriver instance.
        /// </summary>
        /// <param name="driver">The WebDriver instance to use for interaction.</param>
        public AddToCart(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="productName">The name of the product to add.</param>
        /// <param name="quantity">The quantity of the product to add.</param>
        public void AddProductToCart(string productName, int quantity)
        {
            var productElement = driver.FindElement(By.XPath($"//*[@alt='{productName}']"));
            productElement.Click();

            var addToCartButton = driver.FindElement(By.XPath("//*[@id='store-details']/section[1]/div/div[2]/a"));
            addToCartButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@id, 'cart-summary')]")));  // Wait for cart summary
        }

        /// <summary>
        /// Checks if the specified product is in the cart.
        /// </summary>
        /// <param name="productName">The name of the product to check.</param>
        /// <returns>True if the product is in the cart; otherwise, false.</returns>
        public bool IsProductInCart(string productName)
        {
            List<string> cartItems = GetCartItems();
            return cartItems.Any(item => item.Contains(productName));
        }

        /// <summary>
        /// Returns the list of cart items.
        /// </summary>
        /// <returns>A list of cart item names.</returns>
        private List<string> GetCartItems()
        {
            List<string> cartItems = new List<string>();
            var cartItemsElements = driver.FindElements(By.XPath("//div[contains(@id, 'row-')]"));

            foreach (var itemElement in cartItemsElements)
            {
                cartItems.Add(itemElement.Text); // Collect cart item details
            }

            return cartItems;
        }

        /// <summary>
        /// Waits for the URL to contain the specified URL part.
        /// </summary>
        /// <param name="urlPart">The part of the URL to check.</param>
        public void WaitForUrlToContain(string urlPart)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.Url.Contains(urlPart));
        }

        /// <summary>
        /// Simulates clicking the checkout button.
        /// </summary>
        public void ClickCheckoutButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var checkoutButton = wait.Until(driver =>
                driver.FindElement(By.XPath("//*[@id='cart-summary']/div[4]/div/div/a")));  // XPath for the checkout button

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkoutButton); // Scroll into view
            wait.Until(ExpectedConditions.ElementToBeClickable(checkoutButton)).Click(); // Click checkout button

            wait.Until(driver => driver.Url.Contains("/Account/Login?ReturnUrl=%2FCheckout%2FAddressAndPayment"));
        }

        /// <summary>
        /// Gets the current URL of the page.
        /// </summary>
        /// <returns>The current URL as a string.</returns>
        public string GetCurrentUrl()
        {
            return driver.Url;  // This still uses the driver, but only inside the class, not in the test class.
        }

        /// <summary>
        /// Clicks the submit order button.
        /// </summary>
        public void ClickSubmitOrderButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the Submit Order button to be clickable
            var submitOrderButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/section/form/div/div[2]/div[4]/input")));

            // Click the Submit Order button
            submitOrderButton.Click();
        }

        /// <summary>
        /// Dispose method to clean up WebDriver resources.
        /// </summary>
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
