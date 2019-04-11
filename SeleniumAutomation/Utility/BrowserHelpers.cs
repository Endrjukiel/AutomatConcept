using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing.Imaging;
using System.IO;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace SeleniumAutomation.utility
{
    public class BrowserHelpers
    {
        public static ICapabilities capabilities;
        public static ExtentReports extent { get; set; }
        public static ExtentTest test { get; set; }
        // public static string browserName;

        public BrowserHelpers()  //Default Constructor 
        {
            Console.WriteLine("Browser Helpers Constructor");
            ProcessKill();
        }

        /*public static TestContext testContextInstance;

        public static TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }*/

       /* [TestInitialize()]
        public void MyTestInitialize()
        {
            //BrowserHelpers.CreateDriver(BrowserHelpers.TestContext.Properties["Browser"].ToString());
            browserName = TestContext.Properties["Browser"].ToString();
        }*/

        public static IWebDriver driver;

        public static IWebDriver CreateDriver(string browserName)  //chrome  --> CHROME  aa
        {
            switch (browserName.ToUpper())
            {
                case "CHROME":  //TestContext.Parameters["CRM-UserPassword"].ToString()
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("user-data-dir=/ChromeAutomation/profile");
                    //options.AddArguments("–disable-extensions");
                    //options.AddArguments("--enable-popup-blocking");
                    driver = new ChromeDriver(options);
                    break;
                case "IE":
                    //InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    //ieOptions.AcceptInsecureCertificates = true;
                    driver = new InternetExplorerDriver();
                    break;
                default:

                     //FirefoxOptions ffProfile = new FirefoxOptions();
                    // ffProfile.AcceptInsecureCertificates = true;
                    //ffProfile.
                    //ffProfile.
                    //ffProfile.AcceptUntrustedCertificates = true;
                    //ffProfile.AssumeUntrustedCertificateIssuer = true;
                    FirefoxOptions ffoptions = new FirefoxOptions();
                    ffoptions.AcceptInsecureCertificates = true;
                    driver = new FirefoxDriver(ffoptions);
                    break;
            }
            //capabilities = ((RemoteWebDriver)driver).Capabilities;
            //Console.WriteLine("Browser name its running now: "+capabilities.BrowserName);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);            
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void CloseDriver()
        {
            //driver.Close();
            driver.Quit();
            ProcessKill();
        }


        public static void screenshots(string fileName)  /* "loginpage\screenho1 */  
        {
            driver.TakeScreenshot().SaveAsFile(@"..\..\Screenshot\" + fileName+".png");
        }

        public static void ProcessKill()
        {
            List<string> processesToKill = new List<string>() {"Upload", "chromedriver", "geckodriver", "IEDriverServer" };
            foreach (string process in processesToKill)
            {
                Process[] processes = Process.GetProcessesByName(process);
                if (processes.Length > 0)
                {
                    foreach (Process processToKill in processes)
                    {
                        if (!processToKill.HasExited)
                        {
                            processToKill.Kill();
                        }
                    }
                }
            }
        }

        public static void StartReport(TestContext TestContext)
        {
            string reportPath = @"..\..\Reports\AllTestCase_AutomationReport_" + DateTime.Now.ToString("MM_dd_yyyy H_mm") + ".html";
            if (!Directory.Exists(@"..\..\Reports\"))
            { Directory.CreateDirectory(@"..\..\Reports\"); }

            //Append the html report file to current project path
           /* if (!TestContext.Properties["TestRunMode"].ToString().Equals("All"))
            {
                string[] testClassName = TestContext.FullyQualifiedTestClassName.Split('.');
                string rep = testClassName[testClassName.Length - 1];
                if (!Directory.Exists(@"..\..\Reports\" +rep ))
                { Directory.CreateDirectory(@"..\..\Reports\" + rep); }
                // string reportPath = projectPath+"\\Reports\\" + testClassName[5] + "\\" + testClassName[6] + ".html";
                reportPath = @"..\..\Reports\" + rep + "\\TestingReport_" + DateTime.Now.ToString("MM_dd_yyyy H_mm") + ".html";
            }*/

            // initialize the HtmlReporter
            //            Console.WriteLine("Inside test class:" + reportPath);
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.LoadConfig("../../extent-config.xml");
            htmlReporter.AppendExisting = true;
            
            // initialize ExtentReports and attach the HtmlReporter
            extent = new ExtentReports();
            //Add QA system info to html report
            extent.AddSystemInfo("Host Name", Environment.MachineName);
            extent.AddSystemInfo("Environment", "UAT");
            extent.AddSystemInfo("Username", Environment.UserName);
            extent.AddSystemInfo("Browser", TestContext.Properties["Browser"].ToString());
            extent.AttachReporter(htmlReporter);
  
        }

    }
}
