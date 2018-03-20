using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;

namespace WordPress.Framework.Pages
{
    public class AddNewPostPage
    {
        public AddNewPostPage GoTo()
        {
            var element = BrowserManager.Instance.Driver.MouseHover(By.Id("menu-posts"));
            element.FindElement(By.LinkText("Add New")).Click();

            return this;
        }

        public AddNewPostPage SetTitle(string title)
        {
            BrowserManager.Instance.Driver.FindElement(By.Id("title")).SendKeys(title);

            return this;
        }

        public AddNewPostPage SetBody(string body)
        {
            var iframe = BrowserManager.Instance.Driver.FindElement(By.Id("content-ifr"));
            BrowserManager.Instance.Driver.SwitchTo().Frame(iframe);
            //FRAME IFRAME
            BrowserManager.Instance.Driver.SwitchTo().ActiveElement().SendKeys(body);
            //SwitchTo DefaultContent
            BrowserManager.Instance.Driver.SwitchTo().DefaultContent();
            BrowserManager.Instance.Driver.Sleep(); //NOTE

            //DefaultContent
            //...more
            return this;
        }

        public void Publish()
        {
            var button = BrowserManager.Instance.Driver.FindElement(By.Id("publish"));
            //class = button button-primary button-large
            button.WaitForAttributeChange("class", "button button-primary button-large")
                .Click();
        }
    }
}
