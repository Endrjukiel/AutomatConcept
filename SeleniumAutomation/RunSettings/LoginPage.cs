//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using SeleniumAutomation.utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumAutomation.pageObjects
{
    class LoginPage : BrowserHelpers  //inheritance part of oops concept
    {
        public By linkSignIn;
        public By username;
        public By IdentifierNext;
        public By password;
        public By BtnPwdNext;
        
        public string parentwindow; //global variable

        public LoginPage()  // constructor is used to intialize the value for the variable
        {
            //Testing lpt = new Testing();
            linkSignIn = By.XPath("/html/body/nav/div/a[2]");
            username = By.Id("identifierId");
            password = By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input");
            //By.Name("Password")
            IdentifierNext = By.Id("identifierNext");
           BtnPwdNext = By.Id("passwordNext");
        }

        public void GotoPage(String URL)  //URL is local variable
        {
            driver.Navigate().GoToUrl(URL);
            parentwindow = driver.CurrentWindowHandle;
        }

        public void SetUserFields_loginPage(String user)
        {
            //driver.GetType().ToString();
            //if(!driver.GetType().ToString().Contains("Firefox"))

            /* if(!capabilities.BrowserName.Equals("Firefox"))
             { driver.FindElement(linkSignIn).Click(); }*/
            //IWebElement signin = driver.FindElement(By.XPath("/html/body/nav/div/a[2]"));
            //signin.GetAttribute("aria-label").ToString();
            //driver.FindElement(By.XPath("/html/body/nav/div/a[2]")).Click();
            driver.FindElement(linkSignIn).Click();
            IWebElement userButton = driver.FindElement(IdentifierNext);
            driver.FindElement(username).SendKeys(user);
            Assert.AreEqual("Next", userButton.Text,"Mismatch");
            userButton.Click();
            //Assert.IsTrue(driver.Title.Contains("Inbox"),"Inbox page is no displaed");
        }

        public void SetPwdFields_loginPage(String pwd)
        {
            Thread.Sleep(2000);
            IWebElement pwdButton = driver.FindElement(BtnPwdNext);
            driver.FindElement(password).SendKeys(pwd);
            //Assert.AreEqual("Next", pwdButton.Text);
            validationTextPwdButton();
            pwdButton.Click();
        }

        
        public void validationTextPwdButton()
        {
            Assert.AreEqual("Next", driver.FindElement(BtnPwdNext).Text);
        }

    }

}