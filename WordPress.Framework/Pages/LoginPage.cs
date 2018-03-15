using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;

namespace WordPress.Framework.Pages
{
    public class LoginPage
    {
        public static void GoTo()
        {
            BrowserManager.Instance.GoTo();
        }

        public static LoginPageCommand LoginAs(string userName)
        {
            return new LoginPageCommand(userName);
        }
    }

    public class LoginPageCommand
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public LoginPageCommand(string userName)
        {
            UserName = userName;
        }

        public LoginPageCommand WithPassword(string password)
        {
            Password = password;
            return this;
        }

        public void Login()
        {
            //user_login
            BrowserManager.Instance.Driver.FindElement(By.Id("user_login")).SendKeys(UserName);

            //user_pass
            BrowserManager.Instance.Driver.FindElement(By.Id("user_pass")).SendKeys(Password);

            //wp-submit
            BrowserManager.Instance.Driver.FindElement(By.Id("wp-submit")).Click();

        }
    }
}
