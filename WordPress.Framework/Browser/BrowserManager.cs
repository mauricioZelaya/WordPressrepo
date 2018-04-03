using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordPress.Framework.Browser
{
    public static class DriverTime
    {
        public static int DefaultWaitTime = 60;
    }

    public sealed class BrowserManager
    {
        public IWebDriver Driver { get; private set; }
        public WebDriverWait WaitDriver { get; private set; }

        public string Url => "http://wpautomation.azurewebsites.net/wp-login.php";

        private BrowserManager()
        {
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void Init()
        {
            Driver = new DriverManager().DriverFactory();
            WaitDriver = new WebDriverWait(Driver, TimeSpan.FromSeconds(DriverTime.DefaultWaitTime));

            //DELETE THIS
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DriverTime.DefaultWaitTime);
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
        }
        
        public void Close()
        {
            try
            {
                if (Driver != null)
                {
                    Driver.Close();
                    Driver.Quit();
                    Driver.Dispose();
                    Driver = null;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        private static BrowserManager _instance;
        public static BrowserManager Instance => _instance ?? (_instance = new BrowserManager());
    }

    public static class SeleniumExtension
    {
        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            var timeout = new TimeSpan(0, 0, DriverTime.DefaultWaitTime);
            var wait = new WebDriverWait(driver, timeout);

            var javascript = (IJavaScriptExecutor)driver;
            if (javascript == null)
            {
                throw new ArgumentException("driver", @"Driver must support javascript execution");
            }

            wait.Until(d =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                    "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public static void Sleep(this IWebDriver driver, int sleep = 1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(sleep));
        }

        public static IWebElement MouseHover(this IWebDriver driver, By by)
        {
            var action = new Actions(driver);

            IWebElement element = driver.FindElement(by);
            if (element != null)
            {
                action.MoveToElement(element).Build().Perform();
                BrowserManager.Instance.Driver.WaitForPageToLoad();

                return element;
            }

            return null;
        }

        public static IWebElement MouseHover(this IWebElement element)
        {
            var action = new Actions(SeleniumActions.GetWebDriver);

            if (element != null)
            {
                action.MoveToElement(element).Build().Perform();
                BrowserManager.Instance.Driver.WaitForPageToLoad();

                return element;
            }

            return null;
        }

        public static IAlert WaitForAlert(IWebDriver driver)
        {
            try
            {
                SeleniumActions.GetWaitDriver.Until(ExpectedConditions.AlertIsPresent());
                var alert = driver.SwitchTo().Alert();

                return alert;
            }
            catch (Exception ex)
            {
                Thread.Sleep(100);
            }

            return null;
        }

        public static IWebElement WaitForControlIsEnabled(By locator)
        {
            try
            {
                var element = SeleniumActions.GetWaitDriver.Until(ExpectedConditions.ElementToBeClickable(locator));
                return element;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IWebElement WaitForControlIsEnabled(this IWebDriver webDriver, IWebElement locator)
        {
            try
            {
                var element = SeleniumActions.GetWaitDriver.Until(ExpectedConditions.ElementToBeClickable(locator));
                return element;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IWebElement FindElementFromHere(this IWebElement element, By locator)
        {
            try
            {
                var wait = new DefaultWait<IWebElement>(element)
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    PollingInterval = TimeSpan.FromMilliseconds(500)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(NotFoundException),
                    typeof(StaleElementReferenceException));
                var webElement = wait.Until(ele => ele.FindElement(locator));

                return webElement;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IWebElement WaitForAttributeChange(this IWebElement element, string attribute, string expectedValue)
        {
            try
            {
                SeleniumActions.GetWaitDriver.Until(x =>
                {
                    string enabled = element.GetAttribute(attribute);
                    if (enabled.Equals(expectedValue))
                        return true;
                    return false;
                });

                return element;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
