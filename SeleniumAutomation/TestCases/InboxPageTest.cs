using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumAutomation.TestCases
{
    [TestClass]
    public class InboxPageTest: BaseTest
    {
        LoginPageTest loginTest = new LoginPageTest();

        [TestMethod]
        public void InboxMsg()
        {
            loginTest.TC003_NavigateGmail_Chrome();
            Assert.IsTrue(driver.Title.Contains("Inbox"), "Inbox page is not displayed");
        }
    }
}
