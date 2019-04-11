using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.pageObjects;
using SeleniumAutomation.utility;


namespace SeleniumAutomation.TestCases
{
    
   
    [TestClass]   
    
    public class SeleniumConcepts : BaseTest
    {
        DemoHTMLPage lp = new DemoHTMLPage();
        string URL = "../../~/SeleniumAutomation/SeleniumAutomation/Browse.html";

        [TestCategory("Selenium Concepts")]
        [TestMethod]
        [Priority(1)]
        public void TC004_FrameHandling()
        {
            lp.GotoPage(URL);
            lp.framehandling();
        }

        [TestCategory("Selenium Concepts")]
        [TestMethod]
        [Priority(0)]
        public void TC005_ActionTooltipDemo()
        {
            lp.GotoPage(URL);
            lp.ActionDemo();
        }

        [TestCategory("Selenium Concepts")]
        [TestMethod]
        public void TC006_MultipleWindowHandle()
        {
            lp.GotoPage(URL);
            BrowserHelpers.driver.FindElement(By.Id("button1")).Click();
            lp.MultipleWindowHandle();
            BrowserHelpers.driver.SwitchTo().Window(lp.parentwindow);
            BrowserHelpers.driver.FindElement(By.XPath("/html/body/form/button[2]")).Click();
            lp.MultipleWindowHandle();
        }

        [TestCategory("Selenium Concepts")]
        [TestMethod]
        public void TC007_AlertHandling()
        {
            lp.GotoPage(URL);
            BrowserHelpers.driver.FindElement(By.Id("alert")).Click();
            IAlert popup = BrowserHelpers.driver.SwitchTo().Alert();            
            Console.WriteLine(popup.Text);
            popup.Accept();            
        }

        [TestCategory("Selenium Concepts")]
        [TestMethod]
        public void TC008_DropDownHandling()
        {
            lp.GotoPage(URL);
            IWebElement selectDD = BrowserHelpers.driver.FindElement(By.Id("menulist"));
            SelectElement dd = new SelectElement(selectDD);
            dd.SelectByText("Idli");
            dd.SelectByValue("2");
            dd.SelectByIndex(0);
        }

        [TestCategory("Selenium Concepts")]
        [TestMethod]
        public void TC009_JavascriptExecutorDemo()
        {
            lp.GotoPage(URL);
            lp.IjavascriptExecutorDemo();
        }

        [TestCategory("Selenium Concepts")]
        [TestMethod]
        public void TC010_AutoITDemo()
        {
            lp.GotoPage(URL);
            BrowserHelpers.screenshots("DemoHTMLPage");
            lp.callingAutoITExe();
        }

        [TestCategory("Selenium Concepts Dynamic")]
        [TestMethod]
        public void TC011_HandingDynamicLinks()
        {
            lp.GotoPage(URL);
            BrowserHelpers.driver.FindElement(By.LinkText("Google")).Click();  // <a> tag
            BrowserHelpers.driver.Navigate().Back();
            BrowserHelpers.driver.FindElement(By.PartialLinkText("OGL")).Click();
            BrowserHelpers.driver.Navigate().Back();
            BrowserHelpers.driver.FindElement(By.PartialLinkText("ogl")).Click();
        }

        [TestCategory("Selenium Concepts Dynamic")]
        [TestMethod]
        public void TC012_HandingDynamicObjects()
        {
            lp.GotoPage(URL);
            BrowserHelpers.driver.FindElements(By.XPath("//button[starts-with(@id, 'Submit-')]"))[0].Click();
            BrowserHelpers.driver.SwitchTo().Alert().Accept();
            BrowserHelpers.driver.FindElements(By.XPath("//button[starts-with(@id, 'Submit-')]"))[1].Click();
        }
    }
}
