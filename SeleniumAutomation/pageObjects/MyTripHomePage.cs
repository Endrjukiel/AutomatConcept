using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.pageObjects
{
    public class MyTripHomePage
    {
        IWebDriver TestBrowser;
        public string parentwindow;

        public MyTripHomePage(IWebDriver driver)
        {
            TestBrowser = driver;
        }


        public void GotoPage(String URL)  //URL is local variable
        {
            TestBrowser.Navigate().GoToUrl(URL);   //"https://www.makemytrip.com/"
            parentwindow = TestBrowser.CurrentWindowHandle;
        }

        public void SearchFlights()   //IWebDriver driver
        {
            TestBrowser.FindElement(By.Id("hp-widget__sfrom")).Click();
            TestBrowser.FindElement(By.Id("hp-widget__sfrom")).SendKeys("DEL");
            TestBrowser.FindElements(By.XPath("//ul[@id='ui-id-1']/li"))[1].Click();
            //TestBrowser.FindElement(By.XPath("//*[@id='header']/div[3]/div/div[2]/nav/ul/li[4]/a")).Click();
        }

        public void DateHandling()
        {
            /*DatePicker is a table.So navigate to each cell 
            * If a particular cell matches value 13 then select it
            */
            TestBrowser.FindElement(By.Id("hp-widget__depart")).Click();
            //TestBrowser.Manage().Timeouts().implicitlyWait(60, TimeUnit.SECONDS);
            //Click on next so that we will be in next month
            TestBrowser.FindElement(By.XPath(".//*[@id='ui-datepicker-div']/div/a[2]/span")).Click();
            IWebElement dateWidget = TestBrowser.FindElement(By.Id("ui-datepicker-div"));
            List<IWebElement> rows = dateWidget.FindElements(By.TagName("tr")).ToList();
            List<IWebElement> columns = dateWidget.FindElements(By.TagName("td")).ToList();

            foreach (IWebElement cell in columns)
            {
                //Select 13th Date 
                if (cell.Text.Equals("27"))
                {
                    cell.FindElement(By.LinkText("13")).Click();
                    break;
                }

            }
        }
    }
}
