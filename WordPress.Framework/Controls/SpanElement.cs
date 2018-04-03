using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Engine;

namespace WordPress.Framework.Controls
{
    public class SpanElement : WebElementBase
    {
        public SpanElement()
        {

        }

        public SpanElement(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {

        }
    }
}
