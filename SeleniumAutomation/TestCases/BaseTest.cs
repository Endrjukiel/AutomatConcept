using System;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomation.utility;

namespace SeleniumAutomation.TestCases
{
    [TestClass]
    public class BaseTest: BrowserHelpers
    {

        private TestContext testContextInstance;
        public string browserName;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [AssemblyInitialize]
        public static void ClassStartReport(TestContext TestContext)
        {            
           StartReport(TestContext);           
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            //lp = new LoginPage();
            browserName = TestContext.Properties["Browser"].ToString();
            BrowserHelpers.CreateDriver(browserName);
            test = extent.CreateTest(TestContext.TestName);
            
        }

        [TestCleanup]
        // [TearDown]
        public void MyTestCleanup()
        {
            test.Log(Status.Pass, "User name page displayed successfully.");
            BrowserHelpers.CloseDriver();
        }

        [AssemblyCleanup]
        public static void closeReport()
        {
            extent.Flush();
        }
    }
}
