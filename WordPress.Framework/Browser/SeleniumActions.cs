using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordPress.Framework.Browser
{
    public static class SeleniumActions
    {
        private static BrowserManager GetInstance
        {
            get
            {
                if (BrowserManager.Instance != null)
                {
                    return BrowserManager.Instance;
                }

                return null;
            }
        }

        /// <summary>Gets the get web driver.</summary>
        /// <value>The get web driver.</value>
        public static IWebDriver GetWebDriver
        {
            get
            {
                if (GetInstance.Driver != null)
                {
                    return GetInstance.Driver;
                }

                return null;
            }
        }

        public static WebDriverWait GetWaitDriver
        {
            get
            {
                if (GetInstance.Driver != null)
                {
                    return GetInstance.WaitDriver;
                }

                return null;
            }
        }

        public static bool WaitForFrame(By iframe)
        {
            try
            {                
                GetWaitDriver.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(iframe));
                return true;
            }
            catch (Exception ex)
            {
                Thread.Sleep(100);
            }

            return false;
        }

    }
}
