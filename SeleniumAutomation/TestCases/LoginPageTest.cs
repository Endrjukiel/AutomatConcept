using System;
using OpenQA.Selenium;
using SeleniumAutomation.pageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.utility;
using SeleniumAutomation.TestCases;

namespace SeleniumAutomation
{
    //[TestFixture]
    [TestClass]
    public class LoginPageTest: BaseTest
    {
        LoginPage lp=new LoginPage();


        /* [TestMethod]
         public void TC001_NavigateGoogle()
         {
             driver = new ChromeDriver();
             driver.Navigate().GoToUrl("https://www.google.com");
             Console.WriteLine("Title of Page: " + driver.Title);
             Assert.AreEqual("Google", driver.Title);
             Console.WriteLine("Navigate to Google");
             driver.Quit();
         }

         [TestMethod]
         public void TC002_NavigateCegal()
         {
             driver = new ChromeDriver();
             //driver1 = n63ew ChromeDriver();
            // driver1.Navigate().GoToUrl("https://www.google.com");
             Console.WriteLine("Title() of Page:" + driver.Title);
             Console.WriteLine("Navigate to Cegal");
             driver.Quit();
             //driver1.Quit();
           test.AddScreenCaptureFromPath(screenshotPath);
         } */

        [TestCategory("Gmail Login")]
        [TestMethod]
        public void TC003_NavigateGmail_Chrome()
        {
            lp.GotoPage("https://www.gmail.com/");   //lp.GotoPage("https://mail.google.com/mail");
            lp.SetUserFields_loginPage("test");
            lp.SetPwdFields_loginPage("1234");
            //BrowserHelpers.CloseDriver();?8
        }

        [TestCategory("Gmail Login")]
        [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.ODBC", "TestData.xlsx", "GmailLogin", DataAccessMethod.Sequential)]
        //
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\TestData.xlsx;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "GmailLogin$", DataAccessMethod.Sequential)]
        public void TC002_NavigateGmail_Testsdata()
        {
            lp.GotoPage("https://mail.google.com/mail");
            lp.SetUserFields_loginPage(TestContext.DataRow["Username"].ToString());
            lp.SetPwdFields_loginPage(TestContext.DataRow["Pwd"].ToString());
        }                       
    }
}

