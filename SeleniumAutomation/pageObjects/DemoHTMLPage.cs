using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomation.pageObjects
{
    class DemoHTMLPage: BrowserHelpers
    {
        public string parentwindow; //global variable

        public void GotoPage(String URL)  //URL is local variable
        {
            parentwindow = driver.CurrentWindowHandle;
            driver.Navigate().GoToUrl(URL);            
        }

        //added for demo to switch into frame
        public void framehandling()
        {
            //frame window button           
            // IWebElement selectDD1 = driver.FindElement(By.Id("menulist2"));
            //SelectElement dd1 = new SelectElement(selectDD1);
            //dd1.SelectByText("Boost");3d
            driver.SwitchTo().Frame("frame1");
            IWebElement selectDDframe = driver.FindElement(By.Id("menulist2"));
            SelectElement ddframe = new SelectElement(selectDDframe);
            Assert.AreEqual("Coffee", ddframe.SelectedOption.Text);
            BrowserHelpers.screenshots("Before select Boost");
            ddframe.SelectByText("Boost");
            BrowserHelpers.screenshots("After select Boost");
            //parent window button
            driver.SwitchTo().DefaultContent();
            IWebElement selectDD = driver.FindElement(By.Id("menulist"));
            SelectElement dd = new SelectElement(selectDD);
            dd.SelectByText("Pongal");
        }

        public void ActionClassDemo()
        {

            // Click on username textbox
            driver.FindElement(By.XPath(".//*[@id='GmailAddress']")).Click();

            // Create action class object
            Actions builder = new Actions(driver);

            // find the tooltip xpath
            IWebElement username_tooltip = driver.FindElement(By.CssSelector("div.jfk-bubble"));

            // Mouse hover to that text message
            builder.MoveToElement(username_tooltip).Perform();

            // Extract text from tooltip
            String tooltip_msg = username_tooltip.Text;

            // Print the tooltip message just for our refrences
            Console.WriteLine("Tooltip/ Help message is " + tooltip_msg);
        }


        public void ActionDemo()
        {
            // find the tooltip xpath
            IWebElement windowbutton_tooltip = driver.FindElement(By.Id("button1"));

            // Mouse hover to that text message
            //builder.MoveToElement(username_tooltip).Build().Perform();
            //Thread.Sleep(10000);
            // Extract text from tooltip
            String tooltip_msg = windowbutton_tooltip.GetAttribute("title").ToString();

            // Print the tooltip message just for our refrences
            Console.WriteLine("Tooltip/ Help message is " + tooltip_msg);

            // Create action class object
            Actions builder = new Actions(driver);
            builder.MoveToElement(windowbutton_tooltip).Click().Build().Perform();
            //builder.ContextClick();
            builder.SendKeys(Keys.ArrowDown).Build().Perform();
            //builder.SendKeys(Keys.Enter).Build().Perform();
        }

        public void MultipleWindowHandle()
        {
            IReadOnlyCollection<String> handles = new List<string>();
            handles = driver.WindowHandles;
            // Pass a window handle to the other window            

            foreach (String handle1 in handles)
            {
                Console.WriteLine(handle1);
                if (parentwindow != handle1)
                {
                    driver.SwitchTo().Window(handle1);
                    //driver.Manage().Window.Maximize();
                    driver.Close();
                }
            }
        }

        public void IjavascriptExecutorDemo()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("alert('Testing IJavascript Executor')");
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.Id("alert")).Click();
            IAlert popup = driver.SwitchTo().Alert();
            Console.WriteLine(popup.Text);
            popup.Accept();

        }

        public void promptAlert()
        {

            //This line will create alert instance

            IAlert alert = driver.SwitchTo().Alert();

            //It sets the text to alert box

            alert.SendKeys("selenium");
            alert.SendKeys(Keys.Tab);
            //This line will accept the alert
            alert.Accept();
        }

        public void callingAutoITExe()
        {
            driver.FindElement(By.Id("choose")).SendKeys("C:\\Users\\Lenovo\\Desktop\\localhost-1543773767328.log");
            driver.FindElement(By.Id("choose")).Click();
            Thread.Sleep(1000);
            screenshots("WindowScreen");
            Process.Start(@"..\..\WindowsHandlingExe\Upload.exe");
            Thread.Sleep(10000);
        }
    }
}

