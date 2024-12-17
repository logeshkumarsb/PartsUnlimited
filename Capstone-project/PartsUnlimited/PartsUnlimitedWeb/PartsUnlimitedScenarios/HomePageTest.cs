using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PartsUnlimitedWebAdaptors;
using PartsUnlimitedOperations;

namespace PartsUnlimitedScenarios
{
    [TestFixture]
    public class HomePageTests
    {
        private IHomePage homePage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage();
        }

        [Test]
        public void TestBuyFromNewArrival_ValidImage()
        {
            // Arrange
            int imageNum = 1; // Assuming the first product in the New Arrival section

            // Act and Assert
            Assert.DoesNotThrow(() => homePage.BuyFromNewArrival(imageNum), "Clicking New Arrival item failed.");

            homePage.TearDown();
        }

        [Test]
        public void TestBuyFromTopSelling_ValidImage()
        {
            // Arrange
            int imageNum = 1; // Assuming the first product in the Top Selling section

            // Act and Assert
            Assert.DoesNotThrow(() => homePage.BuyFromTopSelling(imageNum), "Clicking Top Selling item failed.");
            homePage.TearDown();
        }

        [Test]
        public void TestGetCurrentBanner()
        {
            // Act
            string bannerUrl = homePage.GetCurrentBanner();

            // Assert
            Assert.IsNotNull(bannerUrl, "Failed to fetch the current banner's URL.");
            Assert.IsTrue(bannerUrl.Contains("http://localhost:5001"), "Banner URL does not match expected format.");
            homePage.TearDown();
        }

        [Test]
        public void TestHoveringImage_ValidImage()
        {
            // Arrange
            int imageNum = 1;  // First product
            int columnNum = 1; // New Arrival column

            // Act
            IWebElement hoveredElement = homePage.HoveringImage(imageNum, columnNum);

            // Assert
            Assert.IsNotNull(hoveredElement, "Hovering over the image did not reveal the expected element.");
            homePage.TearDown();
        }

        [Test]
       public void TestHoveringImage_InvalidImage()
        {
            // Arrange
            int imageNum = 999;  // Invalid product number
            int columnNum = 1;   // New Arrival column

            // Act
            IWebElement hoveredElement = homePage.HoveringImage(imageNum, columnNum);

            // Assert
            Assert.IsNull(hoveredElement, "Hovering on a non-existent image should return null.");
            homePage.TearDown();
        }

        [Test]
        public void TestSlideLeftOfBanner()
        {
            // Act and Assert
            Assert.DoesNotThrow(() => homePage.slideLeftOfBanner(), "Sliding left in the banner failed.");
            homePage.TearDown();
        }

        [Test]
        public void TestSlideRightOfBanner()
        {
            // Act and Assert
            Assert.DoesNotThrow(() => homePage.slideRightOfBanner(), "Sliding right in the banner failed.");
            homePage.TearDown();
        }
    }
}
