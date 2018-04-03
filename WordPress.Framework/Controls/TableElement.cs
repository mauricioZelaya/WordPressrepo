using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;
using WordPress.Framework.Engine;

namespace WordPress.Framework.Controls
{
    public class TableElement : WebElementBase
    {
        //HEADERS
        //COLUMNS
        //ROWS

        private IWebElement _table;

        public TableElement()
        {            
        }

        public TableElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {
            _table = WebElement;
        }

        public IWebElement GetRow(string rowKey)
        {
            return
            _table.FindElementFromHere(By.XPath(".//tr[contains(.,'" + rowKey + "')]"));
        }
    }
}
