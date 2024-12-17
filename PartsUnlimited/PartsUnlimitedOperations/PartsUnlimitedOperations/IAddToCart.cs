using System;
using System.Collections.Generic;

namespace PartsUnlimitedOperations
{
    /// <summary>
    /// Interface for adding products to the cart, checking cart contents, 
    /// and handling the checkout process in an e-commerce web application.
    /// </summary>
    public interface IAddToCart
    {
        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="productName">The name of the product to add to the cart.</param>
        /// <param name="quantity">The number of products to add to the cart.</param>
        void AddProductToCart(string productName, int quantity);

        /// <summary>
        /// Checks if a product is in the cart.
        /// </summary>
        /// <param name="productName">The name of the product to check in the cart.</param>
        /// <returns>True if the product is found in the cart; otherwise, false.</returns>
        bool IsProductInCart(string productName);

        /// <summary>
        /// Simulates clicking the checkout button.
        /// </summary>
        void ClickCheckoutButton();

        /// <summary>
        /// Gets the current URL of the browser.
        /// </summary>
        /// <returns>The current URL as a string.</returns>
        string GetCurrentUrl();

        /// <summary>
        /// Clicks the submit order button to place an order.
        /// </summary>
        void ClickSubmitOrderButton();

        /// <summary>
        /// Waits for the URL to contain the specified URL part.
        /// </summary>
        /// <param name="urlPart">The part of the URL to check.</param>
        void WaitForUrlToContain(string urlPart);
    }
}
