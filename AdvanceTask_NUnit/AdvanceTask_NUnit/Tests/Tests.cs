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

            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","SignIn");
            //LoginPage loginObj = new LoginPage(ExcelUtil.ReadData(1, "Username"), ExcelUtil.ReadData(1, "Password"));


            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","ShareSkills");

                shareSkillObj.AddShareSkill(ExcelUtil.ReadData(2,"Title"), ExcelUtil.ReadData(2,"Description"), ExcelUtil.ReadData(2,"Category"),
                ExcelUtil.ReadData(2,"Subcategory"), ExcelUtil.ReadData(2,"Tag1"), ExcelUtil.ReadData(2,"Tag2"), ExcelUtil.ReadData(2,"ServiceType"), ExcelUtil.ReadData(2,"locationType"),
                ExcelUtil.ReadData(2,"Days"), ExcelUtil.ReadData(2,"StartDate"), ExcelUtil.ReadData(2,"EndDate"), ExcelUtil.ReadData(2,"beginTime"),
                ExcelUtil.ReadData(2,"finishTime"), ExcelUtil.ReadData(2,"SkillTrade"), ExcelUtil.ReadData(2,"SkillExchangeTag"), ExcelUtil.ReadData(2,"Credit"),
                ExcelUtil.ReadData(2,"Active"));
                string listTitle = shareSkillObj.GetManageListing();
                Assert.That(listTitle == "Ballet Dancer", "Listing not found");

         

        }

        [Test, Order(3)]
        public void EditManageListing()
        {
            //test = extent.CreateTest("CEditManageListing");
            ManageListing manageListingObj = new ManageListing();

            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","ManageListing");
            manageListingObj.EditListing(ExcelUtil.ReadData(2,"title"), ExcelUtil.ReadData(2,"description"), ExcelUtil.ReadData(2,"addtags"), ExcelUtil.ReadData(2,"skilltrade"),
                                          ExcelUtil.ReadData(2,"skilltags"), ExcelUtil.ReadData(2,"charge"));
            string manageListingTitle = manageListingObj.GetEditedManageListing();

            Assert.That(manageListingTitle == "All ages Ballet Dancer", "Service listing not updated");


            //test.Log(Status.Pass, "Edited service listing");

        }


        [Test, Order(4)]
        public void MarkAsRead()
        {
            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","SignIn");
            //LoginPage loginObj = new LoginPage(ExcelUtil.ReadData(1, "Username"), ExcelUtil.ReadData(1, "Password"));
            Notifications notificationObj = new Notifications();
            string testResult = notificationObj.MarkAsRead();
            Assert.That(testResult == "400", "Test failed");

        }

        [Test, Order(5)]
        public void DeleteNotification()
        {
            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","SignIn");
            //LoginPage loginObj = new LoginPage(ExcelUtil.ReadData(1, "Username"), ExcelUtil.ReadData(1, "Password"));
            Notifications notificationObj = new Notifications();
            string NotificationText = notificationObj.DeleteNotification();
            Assert.That(NotificationText == "You have no notifications", "Test failed");
        }

        [Test, Order(6)]
        public void AddDescription()
        {
            ProfilePage profileObj = new ProfilePage();
            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","Profile");
            profileObj.AddDescription(ExcelUtil.ReadData(2,"description"));
            string confirmationText = profileObj.ViewConfirmation();
            string descriptionText = profileObj.ViewDescription();
            Assert.That(confirmationText == "Description has been saved successfully","Test failed");
            Assert.That(descriptionText == ExcelUtil.ReadData(2,"description"),"Test failed");
        }

        [Test, Order(7)]
        public void ChangeProfilePassword()
        {
            ProfilePage profileObj = new ProfilePage();
            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");
            profileObj.ChangePassword(ExcelUtil.ReadData(1, "Password"), "newPassword");
            string confirmationText = profileObj.ViewConfirmation();
            Assert.That(confirmationText == "Password Changed Successfully", "Test failed");
        }

        [Test, Order(8)]
        public void ViewReceivedRequestListing()
        {
            ProfilePage profileObj = new ProfilePage();
            string receivedRequestContent = profileObj.VerifyReceivedRequests();
            Assert.That(receivedRequestContent == "Received Requests", "Test failed");
        }

        [Test, Order(9)]
        public void ViewSentRequestListing()
        {
            //Login loginObj;
            ProfilePage profileObj = new ProfilePage();
            string sentRequestContent = profileObj.VerifySentRequests();
            Assert.That(sentRequestContent == "Sent Requests", "Test failed");
        }


        [Test, Order(1), Description("Signup for Portal")]
        public void Register()
        {
            SignUp signUpObj;
            signUpObj = new SignUp();

            string registrationSuccessfulPopUpMessage = signUpObj.GetPopUpMessage(driver);
            Assert.That(registrationSuccessfulPopUpMessage == "Registration successful", "Actual popup message and expected popup message do not match");

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
            Login loginObj;
            loginObj = new Login();
            try
            {
                test = extentReportObj.CreateTest("SignIn for the Portal passed");
                loginObj.LoginSteps();
                Thread.Sleep(5000);

            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }


        }

        [Test, Order(3), Description("Load More Notifications")]

        public void LoadMoreNotification()


        {
            Login loginObj;
            NotificationMoreAndLess notificationObj;
            loginObj = new Login();
            notificationObj = new NotificationMoreAndLess();

            try
            {
                test = extentReportObj.CreateTest("Load More notification on the page");
                loginObj.LoginSteps();
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
            Login LoginObj;
            NotificationMoreAndLess notificationObj;
            LoginObj = new Login();
            notificationObj = new NotificationMoreAndLess();

            try
            {
                test = extentReportObj.CreateTest("Show less notification on the page");
                LoginObj.LoginSteps();
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
