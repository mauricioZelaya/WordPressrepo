using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPress.Framework.Browser;
using WordPress.Framework.Pages;

namespace WordPress.Tests
{
    [TestClass]
    public class UnitTest1
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
            Assert.IsTrue(new DashboardPage().IsAt, "error");
        }

        [TestMethod]
        public void User_Can_Login2()
        {
            Assert.IsTrue(new LoginPage2().GoTo()
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
