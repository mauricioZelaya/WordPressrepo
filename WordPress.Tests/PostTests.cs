using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPress.Framework.Browser;
using WordPress.Framework.Factories;
using WordPress.Framework.Pages;
using WordPress.Framework.RestCalls;
using WordPress.Utilities;

namespace WordPress.Tests
{
    [TestClass]
    public class PostTests
    {
        [TestInitialize]
        public void Init()
        {
            BrowserManager.Instance.Init();
        }

        [TestMethod]
        public void Can_Create_Post()
        {
            //Variables
            //Randon values for Title and Body
            var title = StringManager.GenerateTitle();
            var body = StringManager.GenerateBody();

            //Test Steps
            PageFactory.GetPage<LoginPage2>()
                    .GoTo()
                    .LoginAs("Gonzalo")
                    .WithPassword("Control123!")
                    .Login();

            //Create Post
            PageFactory.GetPage<AddNewPostPage>()
                .GoTo()
                .SetTitle(title)
                .SetBody(body)
                .Publish()
                ;

            PageFactory.GetPage<EditPostPage>()
                .ViewPost();

            //Validation
            //1.
            Assert.IsTrue(PageFactory.GetPage<PostPage>().ValidateTitle(title));

            //2.
            PageFactory.GetPage<PostPage>().ValidateTitle2(title);
        }

        [TestMethod]
        public void Can_Search_Post()
        {
            //Variables
            var title = StringManager.GenerateTitle();
            var body = StringManager.GenerateBody();

            //Test Steps
            PageFactory.GetPage<LoginPage2>()
                    .GoTo()
                    .LoginAs("Gonzalo")
                    .WithPassword("Control123!")
                    .Login();

            //PreCondition
            PostCalls.CreatePost(title, body);
            //Create Post - WEB API



            //Test Steps
            PageFactory.GetPage<AllPostsPage>()            
                .GoTo()
                .SearchPost(title)
                .DoesPostExistWithTitle(title)
                ;

        }


        [TestCleanup]
        public void Clean()
        {
            BrowserManager.Instance.Close();
        }
    }
}
