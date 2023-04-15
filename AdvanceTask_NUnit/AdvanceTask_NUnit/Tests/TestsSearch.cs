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
                
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                test = extentReportObj.CreateTest("Serach Skills", "Searching a Skill").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill search results");
                test.Log(Status.Pass, "Test passed");
                
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
