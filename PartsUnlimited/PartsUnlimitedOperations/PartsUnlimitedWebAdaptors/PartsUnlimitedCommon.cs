using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace PartsUnlimitedWebAdaptors
{
    public class PartsUnlimitedCommon
    {
        protected String Appurl;
        protected IWebDriver driver;
        protected String BrowserName = "chrome";
        public PartsUnlimitedCommon()
        {
            if (BrowserName.StartsWith("chrome"))
            {
                Appurl = "http://localhost:5001/";
                this.driver = new ChromeDriver();
                this.driver.Navigate().GoToUrl(Appurl);
            }
        }
        public PartsUnlimitedCommon(IWebDriver driver)
        {
            if (BrowserName.StartsWith("chrome"))
            {
                Appurl = "http://localhost:5001/";
                this.driver = driver;
                driver.Navigate().GoToUrl(Appurl);
            }
        }

        public void Navigate(int num)
        {
            switch (num)
            {
                case 1:
                    IWebElement HomePage = driver.FindElement(By.XPath("//a[@id='home-link']"));
                    HomePage.Click();
                    break;
                case 2:
                    IWebElement cart = driver.FindElement(By.XPath("//div[normalize-space()='Cart']"));
                    cart.Click();
                    break;
                case 3:
                    IWebElement LogIn = driver.FindElement(By.XPath("//a[@id='login-link']"));
                    LogIn.Click();
                    break;
                case 4:
                    IWebElement Brakes = driver.FindElement(By.XPath("//div[@class='hidden-xs']//a[contains(text(),'Brakes')]"));
                    Brakes.Click();
                    break;
                case 5:
                    IWebElement Lighting = driver.FindElement(By.XPath("//div[@class='hidden-xs']//a[contains(text(),'Lighting')]"));
                    Lighting.Click();
                    break;
                case 6:
                    IWebElement WheelsAndTires = driver.FindElement(By.XPath("//div[@class='hidden-xs']//a[contains(text(),'Wheels & Tires')]"));
                    WheelsAndTires.Click();
                    break;
                case 7:
                    IWebElement Batteries = driver.FindElement(By.XPath("//div[@class='hidden-xs']//a[contains(text(),'Batteries')]"));
                    Batteries.Click();
                    break;
                case 8:
                    IWebElement Oil = driver.FindElement(By.XPath("//div[@class='hidden-xs']//a[contains(text(),'Oil')]"));
                    Oil.Click();
                    break;
                case 9:
                    IWebElement More = driver.FindElement(By.XPath("//div[@class='hidden-xs']//a[normalize-space()='More']"));
                    More.Click();
                    break;
                case 10:
                    IWebElement NewArrival = driver.FindElement(By.XPath("//a[@id='new-arrival']]"));
                    NewArrival.Click();
                    break;
                default:
                    IWebElement DefaultHomePage = driver.FindElement(By.XPath("//a[@id='home-link']"));
                    DefaultHomePage.Click();
                    break;
            }
        }
    }
}