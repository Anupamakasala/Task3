using AdvanceTask_NUnit.Global;
using AdvanceTask_NUnit.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;

namespace AdvanceTask_NUnit.Tests
{
    public class Tests : Base
    {
        [Test, Order(1)]
        public void ACreateShareSkill()
        {
            //test = extent.CreateTest("ACreateShareSkill");

            ShareSkill shareSkillObj = new ShareSkill();

            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");
            LoginPage loginObj = new LoginPage(ExcelUtil.ReadData(1, "Username"), ExcelUtil.ReadData(1, "Password"));


            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "ShareSkills");

            shareSkillObj.AddShareSkill(ExcelUtil.ReadData(1, "title"), ExcelUtil.ReadData(1, "description"), ExcelUtil.ReadData(1, "category"),
                ExcelUtil.ReadData(1, "subcategory"), ExcelUtil.ReadData(1, "addtags"), ExcelUtil.ReadData(1, "serviceType"), ExcelUtil.ReadData(1, "locationType"),
                ExcelUtil.ReadData(1, "daysAvaialable"), ExcelUtil.ReadData(1, "beginDate"), ExcelUtil.ReadData(1, "finishDate"), ExcelUtil.ReadData(1, "starttime"),
                ExcelUtil.ReadData(1, "endtime"), ExcelUtil.ReadData(1, "skilltrade"), ExcelUtil.ReadData(1, "skilltags"), ExcelUtil.ReadData(1, "charge"),
                ExcelUtil.ReadData(1, "active"));
            string shareskillTest = shareSkillObj.GetManageListing();
            Assert.That(shareskillTest == "Ballet Dancer", "Listing not found");

            //test.Log(Status.Pass, "New Service Listing added");

        }

        [Test, Order(3)]
        public void CEditManageListing()
        {
            //test = extent.CreateTest("CEditManageListing");
            ManageListing manageListingObj = new ManageListing();

            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "ManageListing");
            manageListingObj.EditListing(ExcelUtil.ReadData(1, "title"), ExcelUtil.ReadData(1, "description"), ExcelUtil.ReadData(1, "addtags"), ExcelUtil.ReadData(1, "skilltrade"),
                                          ExcelUtil.ReadData(1, "skilltags"), ExcelUtil.ReadData(1, "charge"));
            string editmanagelisitngtest = manageListingObj.GetEditedManageListing();

            Assert.That(editmanagelisitngtest == "All ages Ballet Dancer", "Service listing not updated");


            //test.Log(Status.Pass, "Edited service listing");

        }


        [Test, Order(4)]
        public void MarkAsRead()
        {
            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");
            LoginPage loginObj = new LoginPage(ExcelUtil.ReadData(1, "Username"), ExcelUtil.ReadData(1, "Password"));
            Notifications notificationObj = new Notifications();
            string testResult = notificationObj.MarkAsRead();
            Assert.That(testResult == "400", "Test failed");

        }

        [Test, Order(5)]
        public void DeleteNotification()
        {
            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");
            LoginPage loginObj = new LoginPage(ExcelUtil.ReadData(1, "Username"), ExcelUtil.ReadData(1, "Password"));
            Notifications notificationObj = new Notifications();
            string deletenotificationText = notificationObj.DeleteNotification();
            Assert.That(deletenotificationText == "You have no notifications", "Test failed");
        }

        [Test, Order(6)]
        public void AddDescription()
        {
            ProfilePage profileObj = new ProfilePage();
            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "Profile");
            profileObj.AddDescription(ExcelUtil.ReadData(1, "description"));
            string confirmationText = profileObj.ViewConfirmation();
            string descriptionText = profileObj.ViewDescription();
            Assert.That(confirmationText == "Description has been saved successfully", "Test failed");
            Assert.That(descriptionText == ExcelUtil.ReadData(1, "description"), "Test failed");
        }

        [Test, Order(7)]
        public void ChangeProfilePassword()
        {
            ProfilePage profileObj = new ProfilePage();
            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");
            profileObj.ChangePassword(ExcelUtil.ReadData(1, "Password"), "newPassword");
            string confirmationText = profileObj.ViewConfirmation();
            Assert.That(confirmationText == "Password Changed Successfully", "Test failed");
        }

        [Test, Order(8)]
        public void ViewReceivedRequestListing()
        {
            ProfilePage profileObj = new ProfilePage();
            string receivedRequestText = profileObj.VerifyReceivedRequests();
            Assert.That(receivedRequestText == "You do not have any received requests!", "Test failed");
        }

        [Test, Order(9)]
        public void ViewSentRequestListing()
        {
            ProfilePage profileObj = new ProfilePage();
            string sentRequestText = profileObj.VerifySentRequests();
            Assert.That(sentRequestText == "You do not have any sent requests!", "Test failed");
        }


        [Test, Order(1), Description("Signup for Portal")]
        public void Register()
        {
            SignUp signUpObj;
            signUpObj = new SignUp();
            try
            {
                test = extentReportObj.CreateTest("SignUp for Portal Passed");
                signUpObj.Register();
                Thread.Sleep(2000);


            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }


        }

        [Test, Order(2), Description("SignIn for the Portal")]
        public void LogininSteps()
        {
            LoginPage loginPageObj;
            loginPageObj = new LoginPage();
            try
            {
                test = extentReportObj.CreateTest("SignIn for the Portal passed");
                loginPageObj.LoginSteps();
                Thread.Sleep(2000);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }


        }

        [Test, Order(3), Description("Load More Notifications")]

        public void LoadMoreNotification()


        {
            LoginPage loginPageObj;
            NotificationMoreAndLess notificationObj;
            loginPageObj = new LoginPage();
            notificationObj = new NotificationMoreAndLess();

            try
            {
                test = extentReportObj.CreateTest("Load More notification on the page");
                loginPageObj.LoginSteps();
                notificationObj.LoadMoreNotification();
                Thread.Sleep(2000);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }


        }

        [Test, Order(4), Description("Show Less Notification")]

        public void ShowLessNotification()

        {
            LoginPage loginPageObj;
            NotificationMoreAndLess notificationObj;
            loginPageObj = new LoginPage();
            notificationObj = new NotificationMoreAndLess();

            try
            {
                test = extentReportObj.CreateTest("Show less notification on the page");
                loginPageObj.LoginSteps();
                notificationObj.LoadMoreNotification();
                notificationObj.ShowLessNotification();
                Thread.Sleep(2000);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }

        }
    }
}
