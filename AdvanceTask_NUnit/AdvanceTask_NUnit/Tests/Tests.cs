using AdvanceTask_NUnit.Global;
using AdvanceTask_NUnit.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;

namespace AdvanceTask_NUnit.Tests
{
    public class Tests:Base
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



    }
}
