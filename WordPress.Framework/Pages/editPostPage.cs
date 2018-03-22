using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;

namespace WordPress.Framework.Pages
{
    public class EditPostPage
    {
        public void ViewPost()
        {
            BrowserManager.Instance.Driver.FindElement(By.LinkText("View post"))
                .Click();
        }
    }
}
