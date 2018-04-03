using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPress.Framework.Factories
{
    public class PageFactory
    {
        public static T GetPage<T>() where T : new()
        {
            return new T();           
        }
    }
}
