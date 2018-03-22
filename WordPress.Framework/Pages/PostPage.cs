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
        public bool ValidateTitle(string expecteTitle)
        {
            var actutalTitle = BrowserManager.Instance.Driver
                .FindElement(By.ClassName("entry-title"))
                .Text;

            //LOGS
            
            return actutalTitle.Equals(expecteTitle);
        }

        public void ValidateTitle2(string expecteTitle)
        {
            var actutalTitle = BrowserManager.Instance.Driver
                .FindElement(By.ClassName("entry-title"))
                .Text;

            if (!actutalTitle.Equals(expecteTitle))
            {
                //ERROR
                //EXPECTION
                throw new Exception("Error: The titles are different: " + 
                    "Actual title:" + actutalTitle + 
                    "Expected title: " + expecteTitle);
            }
            else
            {
                //GOOD
                //LOGS
            }

        }
    }
}
