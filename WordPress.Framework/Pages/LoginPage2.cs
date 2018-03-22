using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;

namespace WordPress.Framework.Pages
{
    public class LoginPage2
    {
        public LoginPage2 GoTo()
        {
            BrowserManager.Instance.GoTo();

            return this;
        }

        public LoginPage2 LoginAs(string userName)
        {
            BrowserManager.Instance.Driver
                .FindElement(By.Id("user_login")).SendKeys(userName);

            return this;
        }

        public LoginPage2 WithPassword(string password)
        {
            BrowserManager.Instance.Driver
                .FindElement(By.Id("user_pass")).SendKeys(password);
            
            return this;
        }

        public FromLoginPage2To Login()
        {
            BrowserManager.Instance.Driver
               .FindElement(By.Id("wp-submit")).Click();

            return new FromLoginPage2To();
        }        
    }

    public class FromLoginPage2To
    {
        // < C# 6.0
        //public DashboardPage DashboardPage
        //{
        //    get
        //    {
        //        return new DashboardPage();
        //    }
        //}

        // > C# 6.0
        public DashboardPage DashboardPage => new DashboardPage();

        public TestPage TestPage => new TestPage();
    }
}
