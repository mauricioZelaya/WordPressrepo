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
            LoginPage.GoTo();
            //LoginPage.Login("Gonzalo", "Control123!");
            LoginPage.LoginAs("Gonzalo")
                     .WithPassword("Control123!")
                     .Login();

            //Validation
            Assert.IsTrue(PageFactory<DashboardPage>.GetPage.IsAt, "error");
        }

        [TestMethod]
        public void User_Can_Login2()
        {
            Assert.IsTrue(PageFactory<LoginPage2>.GetPage
                            .GoTo()
                            .LoginAs("Gonzalo")
                            .WithPassword("Control123!")
                            .Login()
                            .GoToDashboardPage.IsAt
            , "error");
        }

        [TestCleanup]
        public void Clean()
        {
            BrowserManager.Instance.Close();
        }
    }
}
