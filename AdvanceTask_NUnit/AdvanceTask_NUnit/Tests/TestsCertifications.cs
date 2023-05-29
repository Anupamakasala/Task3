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
        public void DuplicateCert()
        {
            try
            {
                certObj.ClickCertificationTab();
                string actualmessage = certObj.Duplicate();
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                if (actualmessage == "This information is already exist.")
                {
                    Console.WriteLine(actualmessage);

                    test = extentReportObj.CreateTest("Duplicate Certification", "Testing for the duplicating the certifictaion information").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed when trying to duplicate the certificate");
                    test.Log(Status.Pass, "Test to check the duplicate info- Failed");

                    Assert.Pass("Correct error message");
                }
                else
                {
                    test = extentReportObj.CreateTest("Duplicate Certification", "Testing for the duplicating the certifictaion information").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed when trying to duplicate the certificate");
                    test.Log(Status.Fail, "Test to check the duplicate info- Failed");
                    Assert.Fail("Incorrect Message");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
        }



        [Test, Order(3)]
        public void NegativeNoCertName()
        {
            try
            {
                certObj.ClickCertificationTab();
                string actualmessage = certObj.NegativeTestNoCert();
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                if (actualmessage == "Please enter Certification Name,Certification From and Certification Year")
                {
                    Console.WriteLine(actualmessage);
                    test = extentReportObj.CreateTest("No Certification name", "Testing by leaving the certification name empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed when trying to leave the certificate name field empty");
                    test.Log(Status.Pass, "Test Passed");
                    Assert.Pass("Correct error");
                }
                else
                {
                    test = extentReportObj.CreateTest("No Certification name", "Testing by leaving the certification name empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed when trying to leave the certificate name field empty");
                    test.Log(Status.Fail, "Test  Failed");
                    Assert.Fail("Incorrect Message");
                }
            }

            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
        }


        [Test, Order(4)]
        public void NegativeNoCertYear()
        {
            try
            {
                certObj.ClickCertificationTab();
                string msgActual = certObj.NegativeTestNoCertYear();
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                Console.WriteLine(msgActual);
                if (msgActual == "Please enter Certification Name, Certification From and Certification Year")
                {
                    Console.WriteLine(msgActual);
                    test = extentReportObj.CreateTest("No Certification Year", "Testing by leaving the certification year field empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed when trying to leave the certificate name field empty");
                    test.Log(Status.Pass, "Test Passed");
                    Assert.Pass("Correct error message ");
                }
                else
                {
                    Console.WriteLine(msgActual);
                    test = extentReportObj.CreateTest("No Certification Year", "Testing by leaving the certification Year field empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed when trying to leave the certificate name field empty");
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
                certObj.ClickCertificationTab();
                string msgActual = certObj.NegativeTestNone();
                Console.WriteLine(msgActual);
                if (msgActual == "Please enter Certification Name, Certification From and Certification Year")
                {
                    Console.WriteLine(msgActual);
                    test = extentReportObj.CreateTest("All fields left empty", "Testing by leaving all the certification fields empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed");
                    test.Log(Status.Pass, "Test Passed");
                    Assert.Pass("Correct error message ");
                }
                else
                {
                    Console.WriteLine(msgActual);
                    test = extentReportObj.CreateTest("No Certification Year", "Testing by leaving the certification Year field empty").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed");
                    test.Log(Status.Fail, "Test  Failed");
                    Assert.Fail("Incorrect");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
        }




        [Test,Order(6)]
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

        [Test, Order(7)]
        public void DuplicateUpdateCert()
        {
            try
            {
                certObj.ClickCertificationTab();
                string actualmessage = certObj.DuplicateUpdateCertificate();    
                screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");
                if (actualmessage == "This information is already exist.")
                {
                    Console.WriteLine(actualmessage);

                    test = extentReportObj.CreateTest("Duplicate Certification", "Testing for the duplicating the certifictaion information").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is displayed when trying to duplicate the certificate");
                    test.Log(Status.Pass, "Test to check the duplicate info- Failed");

                    Assert.Pass("Correct error message");
                }
                else
                {
                    test = extentReportObj.CreateTest("Duplicate Certification", "Testing for the duplicating the certifictaion information").AddScreenCaptureFromPath(screenShotPath);
                    test.Log(Status.Info, "Correct Error message is NOT displayed when trying to duplicate the certificate");
                    test.Log(Status.Fail, "Test to check the duplicate info- Failed");
                    Assert.Fail("Incorrect Message");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }
        }



        [Test,Order(8)]
        public void DeleteCertification()
        {
                    
            string deletedCertificateText = certObj.GetDeleteCertificate();
            string originalUpdatedCertText = certObj.GetUpdatedCertificateFromExcel();
            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            certObj.ClickCertificationTab();
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
