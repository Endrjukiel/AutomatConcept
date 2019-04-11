using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation.pageObjects;

namespace SeleniumAutomation.TestCases
{
    [TestClass]
    public class UnitTest1
    {
        //IWebDriver TestBrowser;
        HomePage HP;
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
        [TestCategory("SreeTechConsulting")]
        public void SreeTechConsult()
        {
            //TestBrowser.Navigate().GoToUrl("www.sreetechconsulting.com.au");
            HP.NavigateToServices();
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
