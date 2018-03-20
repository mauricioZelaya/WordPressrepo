using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;

namespace WordPress.Framework.Pages
{
    public class PostPage
    {
        public bool ValidateTitle(string expectedTitle)
        {
            //entry-title
            var actualTitle = BrowserManager.Instance.Driver.FindElement(By.ClassName("entry-title")).Text;

            return actualTitle.Equals(expectedTitle);
        }

        public void ValidateTitle2(string exepectedTitle)
        {
            var actualTitle = BrowserManager.Instance.Driver.FindElement(By.ClassName("entry-title")).Text;

            if (!actualTitle.Equals(exepectedTitle))
            {
                //ERROR
                //EXEPTION
                throw new Exception("Error: The titles are different: " +
                    "Actual title:" + actualTitle +
                    "Expected title" + exepectedTitle);
            }
            else
            {
                //GOOD
                //LOG
            }
        }
    }
}
