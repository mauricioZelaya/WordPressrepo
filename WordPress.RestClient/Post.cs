using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPress.RestClient
{
    public class Post
    {
        public string title { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public string status { get; set; }

        public Post()
        {
            type = "post";
            status = "publish";
        }
    }
              
}
