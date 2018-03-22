using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPress.Framework.Browser
{
    public class DriverManager
    {
        public IWebDriver DriverFactory()
        {
            IWebDriver instance;
            string driverVersion = "Chrome"; //Firefox, Chrome, IE

            switch (driverVersion)
            {
                case "Firefox":
                    instance = new FirefoxDriver();
                    break;
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("disable-infobars");

                    instance = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory + @"\Drivers\", 
                        chromeOptions, 
                        TimeSpan.FromMinutes(2));
                    break;
                case "IE":
                    instance = new InternetExplorerDriver();
                    break;
                default:
                    instance = new FirefoxDriver();
                    break;
            }

            return instance;
        }
    }
}
