using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;
using WordPress.Framework.Factories;
using WordPress.Framework.Pages;
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
            PageFactory<LoginPage2>.GetPage
                    .GoTo()
                    .LoginAs("Gonzalo")
                    .WithPassword("Control123!")
                    .Login();

            //Create Post
            PageFactory<AddNewPostPage>.GetPage            
                .GoTo()
                .SetTitle(title)
                .SetBody(body)
                .Publish()
                ;

            PageFactory<EditPostPage>.GetPage            
                .ViewPost();

            //Validation
            //1.
            Assert.IsTrue(PageFactory<PostPage>.GetPage.ValidateTitle(title));

            //2.
            PageFactory<PostPage>.GetPage.ValidateTitle2(title);
        }

        [TestCleanup]
        public void Clean()
        {
            BrowserManager.Instance.Close();
        }
    }
}
