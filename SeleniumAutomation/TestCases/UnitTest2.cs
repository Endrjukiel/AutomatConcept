using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumAutomation.TestCases
{
    [TestClass]
    public class SeleniumConceptTest
    {
        SelniumCon HP;
        public static IWebDriver driver;

        [TestInitialize]
        public void MyTestInitialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("user-data-dir=E:/AutomationC#/Chrome/profile");
            options.AddArguments("–disable-extensions");
            options.AddArguments("--disable-popup-blocking");
            driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            HP = new HomePage(driver);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
