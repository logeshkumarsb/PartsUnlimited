using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PartsUnlimitedOperations;

namespace PartsUnlimitedWebAdaptors
{
    public class HomePage : PartsUnlimitedCommon, IHomePage
    {
        public HomePage() : base(){
            driver.Navigate().GoToUrl("http://localhost:5001/");
        }
        public HomePage(IWebDriver driver):base(driver) {
            driver.Navigate().GoToUrl("http://localhost:5001/");
        }
        public void BuyFromNewArrival(int imagenum)
        {
            IWebElement product = HoveringImage(imagenum,1);
            Console.WriteLine(product.Text);    
            product.Click();
        }

        public void BuyFromTopSelling(int imagenum)
        {
            IWebElement product = HoveringImage(imagenum, 2);
            Console.WriteLine(product.Text);
            product.Click();
        }

        public string GetCurrentBanner()
        {
            //IWebElement CurrentBanner = driver.FindElement(By.XPath("//div[@class='item active']//a[@class='carousel-wrapper-link']"));
            IWebElement CurrentBanner = driver.FindElement(By.XPath("//div[@class='item active']//a[@class='carousel-link'][normalize-space()='Shop Now']"));
            CurrentBanner.Click();
            return driver.Url;
        }

        public IWebElement HoveringImage(int imagenum, int cloumnnum)
        {
            
            try
            {
                IWebElement imageElement = driver.FindElement(By.XPath($"//body[1]/div[3]/div[1]/section[{cloumnnum}]/div[1]/div[{imagenum}]/div[1]/a[1]/div[1]/div[1]/img[1]"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(imageElement).Perform();
                Console.WriteLine(imageElement.Text);
                return driver.FindElement(By.XPath($"//body[1]/div[3]/div[1]/section[{cloumnnum}]/div[1]/div[{imagenum}]/div[1]/a[1]/div[1]/div[3]"));
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void slideLeftOfBanner()
        {
            IWebElement LeftButton = driver.FindElement(By.XPath("//a[@class='left carousel-control']"));
            LeftButton.Click();
        }

        public void slideRightOfBanner()
        {
            IWebElement RightButton = driver.FindElement(By.XPath("//a[@class='right carousel-control']"));
            RightButton.Click();
        }

        public void TearDown()
        {
           driver.Quit();
        }
    }
}
