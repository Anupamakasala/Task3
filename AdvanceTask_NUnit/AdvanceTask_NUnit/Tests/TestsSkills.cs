using AdvanceTask_NUnit.Global;
using AdvanceTask_NUnit.Pages;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.Base;

namespace AdvanceTask_NUnit.Tests
{
    [TestFixture]
    public class TestsSkills :Base
    {

        Skills skillObj;
        string screenShotPath;


        public TestsSkills()
        {
            skillObj = new Skills();
        }

        [Test, Order(1)]
        public void AddSkills()
        {
            skillObj.ClickSkillTab();
            skillObj.CreateSkillSteps();
            skillObj.SkillsAdd();


            string newskill = skillObj.GetSkill();
            string newskillLevel = skillObj.GetSkillLevel();
            string originalskill = skillObj.GetSkillFromExcel();
            string originalskillLevel = skillObj.GetLevelFromExcel();

            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

                if ((newskill == originalskill) && (newskillLevel == originalskillLevel))
            {

                test = extentReportObj.CreateTest("Create Skill", " Create new Skills").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill record is created successfully");
                test.Log(Status.Pass, "Test passed");

                Assert.Pass("Skill added");
            }
            else
            {
                test = extentReportObj.CreateTest("Create Skill", " Create new Skills").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill record NOT is created successfully");
                test.Log(Status.Pass, "Test Failed");

                Assert.Fail("Fail");
            }
        }

        [Test, Order(2)]
        
        public void UpdateSkills()
        {
            skillObj.ClickSkillTab();
            skillObj.UpdateSkillSteps();
            skillObj.SkillUpdate();



            string newUpdatedSkill = skillObj.GetUpdatedSkill();
            string newUpdatedSkillLevel = skillObj.GetUpdatedSkillLevel();

            string originalUpdatedSkill = skillObj.GetUpdatedSkillFromExcel();
            string originalUpdatedSkillLevel = skillObj.GetUpdatedSkillLevelFromExcel();

            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");


            if ((newUpdatedSkill == originalUpdatedSkill) && (newUpdatedSkillLevel == originalUpdatedSkillLevel))
            {
                test = extentReportObj.CreateTest("Update Skills", " Update the existing Skills").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill record is updated successfully");
                test.Log(Status.Pass, "Test passed");

                Assert.Pass("Skill Updated");
            }
            else
            {
                test = extentReportObj.CreateTest("Update Skills", " Update the existing Skills").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill record is NOT updated ");
                test.Log(Status.Pass, "Test Failed");

                Assert.Fail("Opps Skill NOT updated");
            }
        }


        [Test, Order(3)]
        
        public void DeleteSkills()
        {
            skillObj.DeleteSkillSteps();
            Thread.Sleep(3000);
        
            string deletedSkill = skillObj.GetDeleteSkills();

            string originalUpdatedSkillTobeDeleted = skillObj.GetUpdatedSkillFromExcel();
            string originalUpdatedSkillLevelTobeDeleted = skillObj.GetUpdatedSkillLevelFromExcel();

            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            if (deletedSkill == originalUpdatedSkillTobeDeleted)
            {
                test = extentReportObj.CreateTest("Delete Skill", " Delete Skill record").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill NOT deleted");
                test.Log(Status.Pass, "Test Failed");

                Assert.Fail("Opps Skill NOT Deleted");

            }
            else
            {

                test = extentReportObj.CreateTest("Delete Skill", " Delete Skill record").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill record is Deleted successfully");
                test.Log(Status.Pass, "Test passed");
                Assert.Pass("Skill Deleted");
            }





        }

    }
}
