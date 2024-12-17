using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PartsUnlimitedOperations
{
    public interface IHomePage
    {
        public void slideLeftOfBanner();
        public void slideRightOfBanner();
        public void BuyFromNewArrival(int imagenum);
        public void BuyFromTopSelling(int imagenum);
        public IWebElement HoveringImage(int imagenum,int cloumnnum);
        public String GetCurrentBanner();
        public void TearDown();

    }
}
