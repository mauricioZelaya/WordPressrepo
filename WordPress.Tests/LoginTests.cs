using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPress.Framework.Browser;
using WordPress.Framework.Factories;
using WordPress.Framework.Pages;

namespace WordPress.Tests
{
    [TestClass]
    public class LoginTests
    {
        [TestInitialize]
        public void Init()
        {
            BrowserManager.Instance.Init();
        }

        [TestMethod]
        public void User_Can_Login()
        {
            //Test Steps
            LoginPage.GoTo();            
            LoginPage.LoginAs("Gonzalo")
                     .WithPassword("Control123!")
                     .Login();

            //Validation
            Assert.IsTrue(PageFactory.GetPage<DashboardPage>().IsAt,
                "Error, you are not in the DashboardPage");
        }

        [TestMethod]
        public void User_Can_Login2()
        {
            //Test Steps
            Assert.IsTrue(
                PageFactory.GetPage<LoginPage2>()
                    .GoTo()
                    .LoginAs("Gonzalo")
                    .WithPassword("Control123!")
                    .Login()
                    
                    .DashboardPage
                    .IsAt
                , "Error, you are not in the DashboardPage");   
        }
        
        [TestCleanup]
        public void Clean()
        {
            BrowserManager.Instance.Close();
        }
    }
}
