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
                test.Log(Status.Fail, "Test Failed");

                Assert.Fail("Fail");
            }
        }

        [Test, Order(2)]
        public void DuplicateSkill()
        {
            try
            {
                skillObj.ClickSkillTab();
                string actualmessage = skillObj.Duplicate();
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                if (actualmessage == "This skill is already exist in your skill list.")
                {
                    Console.WriteLine(actualmessage);

                    test = extentReportObj.CreateTest("Duplicate Skill", "Testing for duplicating the Skill information").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed when trying to duplicate the skill");
                    test.Log(Status.Pass, "Test to check the duplicate info- Passed");

                    Assert.Pass("Correct error message ");
                }
                else
                {
                    test = extentReportObj.CreateTest("Duplicate Skill", "Testing for duplicating the Skill information").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed when trying to duplicate the skill");
                    test.Log(Status.Fail, "Test  Failed");
                    Assert.Fail("Incorrect Message");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
        }



        [Test, Order(3)]
        public void NegativeNoSkill()
        {
            try
            {
                skillObj.ClickSkillTab();
                string actualmessage = skillObj.NegativeTestNoSkill();
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                if (actualmessage == "Please enter skill and experience level")
                {
                    Console.WriteLine(actualmessage);
                    test = extentReportObj.CreateTest("Negative Testing with No Skill", "Testing by Not providing Skill field").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed");
                    test.Log(Status.Pass, "Test Passed");
                    Assert.Pass("Correct error mesaage when Skill field is left empty");
                }
                else
                {
                    test = extentReportObj.CreateTest("Negative Testing with No Skill", "Testing by Not providing Skill field").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed");
                    test.Log(Status.Fail, "Test  Failed");
                    Assert.Fail("Incorrect Message");
                }
            }

            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
        }


        [Test, Order(4)]
        public void NegativeNoSkillLevel()
        {
            try
            {
                skillObj.ClickSkillTab();
                string msgActual = skillObj.NegativeTestNoSkillLevel();
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                if (msgActual == "Please enter skill and experience level")
                {
                    Console.WriteLine(msgActual);
                    test = extentReportObj.CreateTest("Negative Testing with No Skill Level", "Testing with Skill Level field empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed");
                    test.Log(Status.Pass, "Test Passed");
                    Assert.Pass("Correct error message when Skill Level field is left empty");
                }
                else
                {
                    Console.WriteLine(msgActual);
                    test = extentReportObj.CreateTest("Negative Testing with No Skill Level", "Testing with Skill Level field empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed");
                    test.Log(Status.Fail, "Test  Failed");

                    Assert.Fail("Incorrect");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
        }

        [Test, Order(5)]
        public void NegativeNone()
        {
            try
            {
                skillObj.ClickSkillTab();
                string msgActual = skillObj.NegativeTestNone();
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                if (msgActual == "Please enter skill and experience level")
                {
                    Console.WriteLine(msgActual);
                    test = extentReportObj.CreateTest("Negative Testing all fields are left empty", "Testing with Skill Level field empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed");
                    test.Log(Status.Pass, "Test Passed");
                    Assert.Pass("Correct error message when all fields are left empty");
                }
                else
                {
                    Console.WriteLine(msgActual);
                    test = extentReportObj.CreateTest("Negative Testing all fields are left empty", "Testing with Skill Level field empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed");
                    test.Log(Status.Fail, "Test  Failed");
                    Assert.Fail("Incorrect");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
        }


        [Test, Order(6)]
        
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
                test.Log(Status.Fail, "Test Failed");

                Assert.Fail("Opps Skill NOT updated");
            }
        }

        [Test, Order(7)]
        public void DuplicateUpdate()
        {
            try
            {
                skillObj.ClickSkillTab();
                string actualmessage = skillObj.DuplicateUpdateSkill();
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                if (actualmessage == "This skill is already added to your skill list.")
                {
                    Console.WriteLine(actualmessage);

                    test = extentReportObj.CreateTest("Duplicate Update Skill", "Testing for duplicating the Update Skill information").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed when trying to duplicate the update skill");
                    test.Log(Status.Pass, "Test to check the duplicate info- Passed");

                    Assert.Pass("Correct error message ");
                }
                else
                {
                    test = extentReportObj.CreateTest("Duplicate Update Skill", "Testing for duplicating the Update Skill information").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed when trying to duplicate the Update skill");
                    test.Log(Status.Fail, "Test  Failed");
                    Assert.Fail("Incorrect Message");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }

        }



            [Test, Order(8)]
        
        public void DeleteSkills()
        {
            skillObj.ClickSkillTab();
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
                test.Log(Status.Fail, "Test Failed");

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
