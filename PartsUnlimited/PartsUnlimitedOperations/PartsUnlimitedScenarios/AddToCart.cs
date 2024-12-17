using OpenQA.Selenium.Support.UI;
using PartsUnlimitedOperations;
using PartsUnlimitedWebAdaptors;
using NUnit.Framework;

namespace PartsUnlimitedScenarios
{
    /// <summary>
    /// Test suite for adding products to the cart, checking cart contents, and the checkout process.
    /// </summary>
    [TestFixture]
    public class AddToCartTests
    {
        private IAddToCart addCart;

        /// <summary>
        /// Setup method to initialize the AddToCart object before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialize the AddToCart adaptor class that encapsulates WebDriver operations
            addCart = new AddToCart();
        }

        /// <summary>
        /// Test to add a product to the cart and verify it was added.
        /// </summary>
        [Test]
        public void AddProductToCartTest()
        {
            string productName = "Matte Finish Rim";

            // Add the product to the cart
            addCart.AddProductToCart(productName, 1);

            // Verify that the product is in the cart
            Assert.IsTrue(addCart.IsProductInCart(productName));  // Ensure that the product was added to the cart
        }

        /// <summary>
        /// Test to check if a product is in the cart after adding it.
        /// </summary>
        [Test]
        public void TestProductIsInCart()
        {
            string productName = "Matte Finish Rim";

            // First add the product to the cart
            addCart.AddProductToCart(productName, 1);

            // Check if the product is present in the cart
            bool isProductInCart = addCart.IsProductInCart(productName);

            // Assert that the product is found in the cart
            Assert.IsTrue(isProductInCart);
        }

        /// <summary>
        /// Test to simulate clicking the checkout button and verify navigation to the correct page.
        /// </summary>
        [Test]
        public void TestCheckoutButtonClick()
        {
            string productName = "Matte Finish Rim";

            // Add the product to the cart
            addCart.AddProductToCart(productName, 1);

            // Verify that the product is in the cart before checking out
            Assert.IsTrue(addCart.IsProductInCart(productName), "Product was not added to the cart.");

            // Simulate clicking the checkout button
            addCart.ClickCheckoutButton();

            // Wait for the URL to change and contain the expected part via the AddToCart class method
            addCart.WaitForUrlToContain("/Account/Login?ReturnUrl=%2FCheckout%2FAddressAndPayment");

            // Get the current URL via the GetCurrentUrl method from the AddToCart class
            string currentUrl = addCart.GetCurrentUrl();

            // Assert that we are on the login page with the correct ReturnUrl
            Assert.IsTrue(currentUrl.Contains("/Account/Login?ReturnUrl=%2FCheckout%2FAddressAndPayment"),
                "The checkout button did not navigate to the login page. Current URL: " + currentUrl);
        }

        /// <summary>
        /// TearDown method to clean up WebDriver resources after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Dispose of the WebDriver instance to release resources after the test
            if (addCart is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
