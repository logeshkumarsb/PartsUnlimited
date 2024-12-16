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
            if (BrowserName.StartsWith("chrome")) {
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
    }
}
