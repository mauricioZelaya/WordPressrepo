using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;

namespace WordPress.Framework.Pages
{
    public class DashboardPage
    {
        public bool IsAt
        {
            get
            {
                var h1s =
                BrowserManager.Instance.Driver
                    .FindElements(By.TagName("h1"));

                if (h1s != null && h1s.Count > 0)
                {
                    return h1s[0].Text.Equals("Dashboard");
                }

                return false;
            }
        }
    }
}
