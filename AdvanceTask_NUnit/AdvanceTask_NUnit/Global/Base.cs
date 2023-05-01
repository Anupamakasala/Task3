using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceTask_NUnit.Pages;

namespace AdvanceTask_NUnit.Global
{
    public class Base
    {
        public static IWebDriver driver;

        // Define other objects here        
        public static string excelPath = @"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx";
        public static ExtentReports extentReportObj = null;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;
    




        static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName +
        Path.DirectorySeparatorChar + "ExtentReports" +
        Path.DirectorySeparatorChar + "Result " + DateTime.Now.ToString("ddMMyyyy HHmmss");


        [OneTimeSetUp]
        public void LoginActions()
        {

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extentReportObj = new ExtentReports();
            extentReportObj.AttachReporter(htmlReporter);

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            Wait_Helpers.wait(10);
                        
           Login loginObj = new Login();
           loginObj.LoginSteps();

        }



        public class GetScreenShot
        {
            public static string Capture(IWebDriver driver, string screenShotName)
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().Location;
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Screenshots\\" + screenShotName + ".png";
                string localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
                return localpath;
            }
        }



        //[OneTimeTearDown]
        //public void Close()
        //{

           // extentReportObj.Flush();
           // driver.Quit();

       // }

    }
}
