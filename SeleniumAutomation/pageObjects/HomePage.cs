using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.pageObjects
{
    public class HomePage
    {
        IWebDriver TestBrowser;
        public HomePage(IWebDriver driver)
        {
            TestBrowser = driver;
        }

        public void NavigateToServices()   //IWebDriver driver
        {
            TestBrowser.Navigate().GoToUrl("http://www.sreetechconsulting.com.au");
            //TestBrowser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            TestBrowser.FindElement(By.XPath("//*[@id='header']/div[3]/div/div[2]/nav/ul/li[4]/a")).Click();
            //driver.FindElement(By.XPath("//*[@id='header']/div[3]/div/div[2]/nav/ul/li[4]/a")).Click();
        }
    }
}
