using AdvanceTask_NUnit.Global;
using AdvanceTask_NUnit.Pages;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_NUnit.Tests
{
    [TestFixture]
    public class TestsSearch : Base
    {

        SearchSkills srch;
        string screenShotPath;
        public TestsSearch()
        {
            srch = new SearchSkills();

        }

        [Test, Order(1)]

        public void Search()
        {
            try
            {
                srch.SearchSkillSteps();
                srch.ClickAllCat();
                srch.ClickCategory();
                srch.ClickSubCategory();
                string boldPt = srch.BoldClickCategory();
                string boldQa = srch.BoldClickSubCategory();
                srch.ClickSearchSkillInner();
                srch.UserSearch();
                string location_Type = srch.FilterOnline();
                Console.WriteLine(location_Type);
                string location_Type2 = srch.FilterOnsite();
                Console.WriteLine(location_Type2);
                string location_Type3 = srch.FilterShowAll();
                Console.WriteLine(location_Type3);
                string location_Type4 = srch.FilterShowAll2();
                Console.WriteLine(location_Type4);
                srch.ClickRefresh();          
                string refine = srch.VerifySearch();   
                
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");            

                if ((refine == "Refine Results") && (boldPt == "400") && (boldQa == "400") && (location_Type == "Online") && (location_Type2 == "On-Site") && (location_Type3 == "Online") && (location_Type4 == "On-Site"))
                {                    
                    test = extentReportObj.CreateTest("Search a Skill", " Searching skills and applying Filters").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Searching the skills for transaction");
                    test.Log(Status.Pass, "Test passed");                    
                    Assert.Pass("Pass");
                    screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

                }
                else
                {
                    test = extentReportObj.CreateTest("Search a Skill", " Searching skills and applying Filters").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Searching the skills for transaction");
                    test.Log(Status.Fail, "OOPs! Search Skill Test Failed");
                    Assert.Fail("OOps! Test Fail");
                }             
                
            }

            catch (NoSuchElementException e)
            {
                test = extentReportObj.CreateTest("Search Skills", "Searching a Skill").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill search results");
                test.Log(Status.Fail, "Test Failed");
                test.Fail(e.StackTrace);
            }
        }

    }
}
