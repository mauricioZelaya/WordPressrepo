using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;
using WordPress.Framework.Controls;
using WordPress.Framework.Engine;
using WordPress.Framework.Factories;

namespace WordPress.Framework.Pages
{
    public class DashboardPage
    {
        public bool IsAt
        {
            get
            {
                //var h1s =
                //BrowserManager.Instance.Driver
                //    .FindElements(By.TagName("h1"));

                //if (h1s != null && h1s.Count > 0)
                //{
                //    return h1s[0].Text.Equals("Dashboard");
                //}

                //return false;

                var h1s = 
                ControlFactory.GetControl<SpanElement>
                    (Locator.TagName, "h1", "Dashboard Header").WebElements;

                if (h1s.Any())
                {
                    return h1s.First().Text.Equals("Dashboard");
                }

                return false;
            }
        }
    }
}
