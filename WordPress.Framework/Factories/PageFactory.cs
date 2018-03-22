using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPress.Framework.Factories
{
    public class PageFactory<T> where T : new()
    {
        public static T GetPage
        {
            get
            {
                //LOGS

                return new T();
            }
        }
    }
}
