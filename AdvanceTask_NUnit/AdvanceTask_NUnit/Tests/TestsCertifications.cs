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
        Certifications CertObj;        
        string screenShotPath;


        public TestsCertifications()
        {

            CertObj = new Certifications();

           
        }

        [Test, Order(1)]

        public void AddCertfication()
        {
            
            CertObj.ClickCertificationTab();
            CertObj.CertificationSteps();
            CertObj.CertificationAdd();

            string newCertText = CertObj.GetCertificate();
            Console.WriteLine(newCertText);
            string originalCertText = CertObj.GetCertificateFromExcel();
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
            CertObj.ClickCertificationTab();
            CertObj.UpdateCertificationSteps();
            CertObj.CertificationUpdate();

            string NewUpdatedCertificate = CertObj.GetUpdatedCertificate();
            string originalUpdatedCertText = CertObj.GetUpdatedCertificateFromExcel();
            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            
            //Verify Update

            if (NewUpdatedCertificate == originalUpdatedCertText)
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
                    
            string DeletedCertificateText = CertObj.GetDeleteCertificate();
            string orginalUpdatedCertText = CertObj.GetUpdatedCertificateFromExcel();
            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            CertObj.DeleteCertificate();

            //Verify Delete

            if (DeletedCertificateText == orginalUpdatedCertText)
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
