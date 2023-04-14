using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using AdvanceTask_NUnit.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;



namespace AdvanceTask_NUnit.Global
{
    public class Base
    {
        public static IWebDriver driver;
        #region
        // Define other objects here

        public static ExtentReports extentReportObj = null;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;

        static string excelPath = @"C:\Users\Admin\source\repos\Mars Advanced Nunit\Mars Advanced Nunit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx";
        static string reportPath = @"C:\Users\Admin\source\repos\Mars Advanced Nunit\Mars Advanced Nunit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestReport";
   
        #endregion

        public static string ExcelPath { get => excelPath; set => excelPath = value; }
   

        [OneTimeSetUp]
        public void LoginActions()
        {

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extentReportObj = new ExtentReports();
            extentReportObj.AttachReporter(htmlReporter);


        }

        [SetUp]
        public void Inititalize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();


            //Load Excel
            
           ExcelUtil.PopulateInCollection(Base.excelPath, "LoginPage");

            //Open URL
            driver.Navigate().GoToUrl(ExcelUtil.ReadData(2, "Url"));

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



        [OneTimeTearDown]
        public void Close()
        {

            extentReportObj.Flush();
           // driver.Quit();

        }

    }
}
