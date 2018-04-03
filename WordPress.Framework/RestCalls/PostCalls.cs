using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.RestClient;

namespace WordPress.Framework.RestCalls
{
    public class PostCalls
    {
        public static void CreatePost(string title, string body)
        {
            Post post = new Post();
            post.title = title;
            post.content = body;

            RestClientManager.Instance.Create("", post);
        }
    }
}
