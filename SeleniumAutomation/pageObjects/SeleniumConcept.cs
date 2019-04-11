using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomation.pageObjects
{
    public class SeleniumConcept
    {
        IWebDriver TestBrowser;
        public string parentwindow;

        public SeleniumConcept(IWebDriver driver)
        {
            TestBrowser = driver;
        }

        public void GotoPage(String URL)  //URL is local variable
        {
            TestBrowser.Navigate().GoToUrl(URL);
            parentwindow = TestBrowser.CurrentWindowHandle;
        }

        public void framehandling()
        {
            //frame window button           
            /* IWebElement selectDD = driver.FindElement(By.Id("menulist2"));
             SelectElement dd = new SelectElement(selectDD);
             dd.SelectByText("Boost");*/
            TestBrowser.SwitchTo().Frame("frame1");
            IWebElement selectDDframe = TestBrowser.FindElement(By.Id("menulist2"));
            SelectElement ddframe = new SelectElement(selectDDframe);
            ddframe.SelectByText("Boost");

            //parent window button
            TestBrowser.SwitchTo().DefaultContent();
            IWebElement selectDD = TestBrowser.FindElement(By.Id("menulist"));
            SelectElement dd = new SelectElement(selectDD);
            dd.SelectByText("Pongal");
        }

        public void ActionClassDemo()
        {

            // Click on username textbox
            TestBrowser.FindElement(By.XPath(".//*[@id='GmailAddress']")).Click();

            // Create action class object
            Actions builder = new Actions(TestBrowser);

            // find the tooltip xpath
            IWebElement username_tooltip = TestBrowser.FindElement(By.CssSelector("div.jfk-bubble"));

            // Mouse hover to that text message
            builder.MoveToElement(username_tooltip).Perform();

            // Extract text from tooltip
            String tooltip_msg = username_tooltip.Text;

            // Print the tooltip message just for our refrences
            Console.WriteLine("Tooltip/ Help message is " + tooltip_msg);
        }

        public void MultipleWindowHandle()
        {
            IReadOnlyCollection<String> handles = new List<string>();
            handles = TestBrowser.WindowHandles;
            // Pass a window handle to the other window            

            foreach (String handle1 in handles)
            {
                Console.WriteLine(handle1);
                if (parentwindow != handle1)
                {
                    TestBrowser.SwitchTo().Window(handle1);
                    //TestBrowser.Manage().Window.Maximize();
                    TestBrowser.Close();
                }
            }
        }

        public void IjavascriptExecutorDemo()
        {
            ((IJavaScriptExecutor)TestBrowser).ExecuteScript("alert('Testing IJavascript Executor')");
            Thread.Sleep(2000);
            TestBrowser.SwitchTo().Alert().Accept();
            TestBrowser.FindElement(By.Id("alert")).Click();
            IAlert popup = TestBrowser.SwitchTo().Alert();
            Console.WriteLine(popup.Text);
            popup.Accept();
            //popup.Dismiss();// cancel  button in Alert popup
        }

        public void promptAlert()
        {

            //This line will create alert instance

            IAlert alert = TestBrowser.SwitchTo().Alert();

            //It sets the text to alert box

            alert.SendKeys("selenium");
            alert.SendKeys(Keys.Tab);
            //This line will accept the alert
            alert.Accept();
        }

        public void callingAutoITExe()
        {
            TestBrowser.FindElement(By.Id("choose")).Click();
            Thread.Sleep(1000);
            //screenshots("WindowScreen");
            Process.Start(@"..\..\WindowsHandlingExe\Upload.exe");
            Thread.Sleep(10000);
        }
    }
}
