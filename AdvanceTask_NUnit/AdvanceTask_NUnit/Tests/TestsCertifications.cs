using AdvanceTask_NUnit.Global;
using AdvanceTask_NUnit.Pages;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdvanceTask_NUnit.Tests
{

    [TestFixture]
    public class TestsCertifications : Base
    {
        Certifications certObj;        
        string screenShotPath;
        
        

        public TestsCertifications()
        {
            
            
            certObj = new Certifications();

           
        }

        [Test, Order(1)]

        public void AddCertfication()
        {
            
            certObj.ClickCertificationTab();
            certObj.CertificationSteps();
            certObj.CertificationAdd();

            string newCertText = certObj.GetCertificate();
            Console.WriteLine(newCertText);
            string originalCertText = certObj.GetCertificateFromExcel();
            Console.WriteLine(originalCertText);
            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
            
            //Verify Add

            if (newCertText == originalCertText)
            {
                test = extentReportObj.CreateTest("Create Certifications", " Create new Certifications").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Certifications record is created successfully");
                test.Log(Status.Pass, "Test passed");
                Assert.Pass("Certifications are added successfully");
            }
            else
            {

                test = extentReportObj.CreateTest("Create Certifications", " Create new Certifications").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Certifications record is NOT created successfully");
                test.Log(Status.Pass, "Test Failed");
                Assert.Fail("Certifications are NOT added");
            }

        }

        [Test, Order(2)]
        public void UpdateCertification()
        {
            
            certObj.ClickCertificationTab();
            certObj.UpdateCertificationSteps();
            certObj.CertificationUpdate();

            string newUpdatedCertificate = certObj.GetUpdatedCertificate();
            string originalUpdatedCertText = certObj.GetUpdatedCertificateFromExcel();
            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            
            //Verify Update

            if (newUpdatedCertificate == originalUpdatedCertText)
            {
                test = extentReportObj.CreateTest("Create Skill", " Create new Skills").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Certifications  record is updated successfully");
                test.Log(Status.Pass, "Test passed");

                Assert.Pass("Update Pass");
            }
            else
            {
                test = extentReportObj.CreateTest("Update Certifications", " Update existing Certifications").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Certifications record is NOT updated");
                test.Log(Status.Pass, "Test Failed");

                Assert.Fail("Update Fail");
            }
        }


        [Test, Order(3)]
        public void DeleteCertification()
        {
                    
            string deletedCertificateText = certObj.GetDeleteCertificate();
            string originalUpdatedCertText = certObj.GetUpdatedCertificateFromExcel();
            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            
            certObj.DeleteCertificate();

            //Verify Delete

            if (deletedCertificateText == originalUpdatedCertText)
            {
                test = extentReportObj.CreateTest("Delete Certifications", " Delete existing Certifications").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Certifications record is NOT Deleted");
                test.Log(Status.Pass, "Test Failed");

                Assert.Fail("Record Not Deleted,Test Failed");

            }
            else
            {
                test = extentReportObj.CreateTest("Delete Certifications", " Delete existing Certifications").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Certifications record is deleted successfully");
                test.Log(Status.Pass, "Test passed");

                Assert.Pass("Record Deleted,Test Passed");
            }
        }


    }
        }
