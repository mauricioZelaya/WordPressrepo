using OpenQA.Selenium;
using System.Collections.Generic;
using WordPress.Framework.Browser;
using WordPress.Logger;

namespace WordPress.Framework.Engine
{
    public class WebElementBase
    {
        public By By { get; set; }
        public string ControlName { get; set; }

        public WebElementBase()
        {

        }

        public WebElementBase(Locator locator, 
                              string value,
                              string controlName)
        {
            ControlName = controlName;
            SearchProperty(locator, value);
        }

        private void SearchProperty(Locator locator,
                                    string value)
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
                case Locator.TagName:
                    By = By.TagName(value);
                    break;
                 //TODO: complete all the locators
            }
        }

        public void Click()
        {
            WebElement.Click();

            //Log
            var message = $"The (Control) [ {ControlName} ] was clicked";
            LoggerManager.Instance.Information(message);

            //Log
            //var message2 = $"The (Button) [ {ControlName} ] is displayed";
            //var message3 = $"the (TextField) [ {ControlName} contains]" + $" the WRONG value: [ {currentValue} ], when it " +
            //    $" should contain the expected value: [ {expectedValue} ].";
            //var message4 = $"the (TextField) [ {ControlName} contains]" + $" the CORRECT value: [ {currentValue} ]";
        }

        public IWebElement MouseHover()
        {
            return WebElement.MouseHover();
        }

        //GET TEXT
        //DrawHighlight


        private IWebElement _webElement;
        public IWebElement WebElement
        {
            get
            {
                if (_webElement == null)
                {
                    var webElement = new WebElementFinder(this);
                    _webElement = webElement.FindElement();
                }

                return _webElement;
            }
        }

        private IReadOnlyCollection<IWebElement> _webElements;
        public IReadOnlyCollection<IWebElement> WebElements
        {
            get
            {
                if (_webElements == null)
                {
                    var webElement = new WebElementFinder(this);
                    _webElements = webElement.FindElements();
                }

                return _webElements;
            }
        }
    }
}
