using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPress.Framework.Engine
{
    public class WebElementBase
    {
        public By By { get; set; }
        public string ControlName { get; set; }

        public WebElementBase()
        {

        }

        public WebElementBase(Locator locator, string value, string controlName)
        {
            ControlName = controlName;
            SearchProperty(locator, value);         
        }

        private void SearchProperty(Locator locator, string value)
        {
            switch (locator)
            {
                case Locator.Id:
                    By = By.Id(value);
                    break;
                case Locator.Name:
                    By = By.Name(value);
                    break;
                case Locator.XPath:
                    By = By.XPath(value);
                    break;
                case Locator.ClassName:
                    By = By.ClassName(value);
                    break;

                    //TODO: complete all the lcators

            }
        }

        public void Click()
        {
            WebElement.Click();
        }

        private IWebElement _webElement;

        public IWebElement WebElement
        {
            get {
                    if (_webElement == null)
                    {
                    var webElement = new WebElementFinder(this);
                    _webElement = webElement.FindElement();
                    }
                    return _webElement;
                }
        }

    }
}
