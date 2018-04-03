using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Engine;

namespace WordPress.Framework.Controls
{
    public class TextFieldElement : WebElementBase
    {
        public TextFieldElement()
        {

        }

        public TextFieldElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {

        }

        public void SetValue(string text)
        {
            WebElement.Clear();
            WebElement.SendKeys(text);

            //LOG
        }
    }
}
