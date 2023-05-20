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
                srch.UserSearch();                
                srch.ClickRefresh();
                srch.ClickSearchSkillInner();
                srch.Filters();


                string refine = srch.VerifySearch();
                string boldPt = srch.BoldClickCategory();
                string boldQa = srch.BoldClickSubCategory();

                if ((refine == "Refine Results") && (boldPt == "400") && (boldQa == "400"))
                {

                    screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                    test = extentReportObj.CreateTest("Search a Skill", " Searching skills and applying Filters").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Searching the skills for transaction");
                    test.Log(Status.Pass, "Test passed");
                    Assert.Pass("Pass");
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
                test = extentReportObj.CreateTest("Serach Skills", "Searching a Skill").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill search results");
                test.Log(Status.Fail, "Test Failed");
                test.Fail(e.StackTrace);
            }
        }

    }
}
