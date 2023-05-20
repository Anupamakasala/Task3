using AdvanceTask_NUnit.Global;
using AdvanceTask_NUnit.Pages;
using NUnit.Framework;
<<<<<<< HEAD
using OpenQA.Selenium;
=======
using OpenQA.Selenium.Support.UI;
>>>>>>> origin/Jyoti-Branch
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
<<<<<<< HEAD
        [Test, Order(1)]
        public void ACreateShareSkill()
        {
            //test = extent.CreateTest("ACreateShareSkill");

            ShareSkill shareSkillObj = new ShareSkill();

<<<<<<< HEAD
            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");
=======
            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","SignIn");
>>>>>>> be38c4ae7b920d285aa4cebcf8d37f2f05f762c6
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
<<<<<<< HEAD
            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");
=======
            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","SignIn");
>>>>>>> be38c4ae7b920d285aa4cebcf8d37f2f05f762c6
            //LoginPage loginObj = new LoginPage(ExcelUtil.ReadData(1, "Username"), ExcelUtil.ReadData(1, "Password"));
            Notifications notificationObj = new Notifications();
            string testResult = notificationObj.MarkAsRead();
            Assert.That(testResult == "400", "Test failed");

        }

        [Test, Order(5)]
        public void DeleteNotification()
        {
<<<<<<< HEAD
            ExcelUtil.PopulateInCollection(@"C:\IndustryConnect\AdvancedTask\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");
=======
            ExcelUtil.PopulateInCollection(@"C:\Users\Admin\Downloads\Nunit Advanced\Task3-Test-case-and-Condition-Skillshare\AdvanceTask_NUnit\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx","SignIn");
>>>>>>> be38c4ae7b920d285aa4cebcf8d37f2f05f762c6
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
<<<<<<< HEAD
            Login loginPageObj;
            loginPageObj = new Login();
=======
            Login loginObj;
            loginObj = new Login();
>>>>>>> be38c4ae7b920d285aa4cebcf8d37f2f05f762c6
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
<<<<<<< HEAD
            Login loginPageObj;
            NotificationMoreAndLess notificationObj;
            loginPageObj = new Login();
=======
            Login loginObj;
            NotificationMoreAndLess notificationObj;
            loginObj = new Login();
>>>>>>> be38c4ae7b920d285aa4cebcf8d37f2f05f762c6
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
<<<<<<< HEAD
            Login loginPageObj;
            NotificationMoreAndLess notificationObj;
            loginPageObj = new Login();
=======
            Login LoginObj;
            NotificationMoreAndLess notificationObj;
            LoginObj = new Login();
>>>>>>> be38c4ae7b920d285aa4cebcf8d37f2f05f762c6
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

//=======
        LoginPage loginPageobj;
        ProfilePage profilePageobj;
        EducationPage educationPageobj;
        ManageListingPg manageListingPgobj;



        [SetUp]
        public void SignIn()
        {

            loginPageobj = new LoginPage();
            profilePageobj = new ProfilePage();
            educationPageobj = new EducationPage();
            manageListingPgobj = new ManageListingPg();

        }

        [Test]
        public void Education_Test()
        {
            loginPageobj.SigninActions();
            profilePageobj.ClickonEducation();
            educationPageobj.AddEducation();
        }
        [Test]
        public void DeleteListing_Test()
        {

            loginPageobj.SigninActions();
            profilePageobj.ManageListings();
            manageListingPgobj.DeleteSkill();

        }
        [Test]
        public void Chat_Test()
        {
            loginPageobj.SigninActions();
            ChatPage chatPageobj = new ChatPage();
            chatPageobj.OpenChatTextbox();

        }
        [TearDown]
        public void CloseTestrun()
        {

            driver.Quit();
//>>>>>>> origin/Jyoti-Branch
        }
        }

        /***********************************************************************
        ** Added by Heather
        ************************************************************************/
        
        [Test, Order(21)]
        public void AddLanguage_Test()
        {
            // Profile page object initialization and definition
            ProfilePage ProfilePageObj = new ProfilePage();
            ProfilePageObj.GoToLanguageTab(driver);

            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "Languages");

            string languageName = ExcelUtil.ReadData(2, "LanguageName");
            string languageLevel = ExcelUtil.ReadData(2, "languageLevel");

            LanguageTab LanguageTabObj = new LanguageTab();
            LanguageTabObj.AddLanguage(driver, languageName, languageLevel);

            //Console.WriteLine("languageName as input : " + languageName);
            string newLang = LanguageTabObj.GetLangName(driver);
            //Console.WriteLine("newLang get from table: " + newLang);
            Assert.That(newLang == languageName, "Add Language Test Failed");
        }

        [Test, Order(22)]
        public void EditLanguage_Test()
        {
            ProfilePage ProfilePageObj = new ProfilePage();
            ProfilePageObj.GoToLanguageTab(driver);

            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "Languages");

            string editLanguageName = ExcelUtil.ReadData(3, "LanguageName");
            string editLanguageLevel = ExcelUtil.ReadData(3, "languageLevel");
            
            LanguageTab LanguageTabObj = new LanguageTab();
            LanguageTabObj.EditLanguage(driver, editLanguageName, editLanguageLevel);

            Console.WriteLine("1. editLanguageName: " + editLanguageName);

            Thread.Sleep(10);
            string GetEditedLang = LanguageTabObj.GetLangName(driver);
            //Console.WriteLine("2. GetEditedLang : " + GetEditedLang);
            Assert.That(GetEditedLang == editLanguageName, "Edit Language Test Failed");
        }

        [Test, Order(23)]
        public void DeleteLang_Test()
        {
            // Profile page object initialization and definition
            ProfilePage ProfilePageObj = new ProfilePage();
            ProfilePageObj.GoToLanguageTab(driver);

            LanguageTab LanguageTabObj = new LanguageTab();
            LanguageTabObj.DeleteLang(driver);

            //Assert notification
            string notification = LanguageTabObj.DeleteLangConfirm(driver);
            Assert.That(notification.Contains ("has been deleted from your languages"), "Delete language failed");
            
        }

              [Test, Order(24)]
        public void LocationElementExists()
        {
            ProfileExtra profileExtraObj = new ProfileExtra();
            String text = profileExtraObj.LocationElement();
            Assert.That(text == "Location", "Location element does not exist");
        }

        [Test, Order(25)]
        public void AddAvailabilityTest() 
        {
            ProfileExtra profileExtraObj = new ProfileExtra();
            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "ProfileExtra");

            string availability = ExcelUtil.ReadData(2, "Availability");
            profileExtraObj.EditAvailability(availability);

            string addedAvailability = profileExtraObj.GetAvailability();
            Assert.That(addedAvailability == availability, "Add availability failed");
        }

        [Test, Order(26)]
        public void EditAvailabilityTest()
        {
            ProfileExtra profileExtraObj = new ProfileExtra();
            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "ProfileExtra");

            string availability = ExcelUtil.ReadData(3, "Availability");
            profileExtraObj.EditAvailability(availability);

            //Console.WriteLine("1.expected availability(input): " + availability);
            string editedAvailability = profileExtraObj.GetAvailability();
            //Console.WriteLine("2. actual editedAvailability Hours : " + editedAvailability);
            Assert.That(editedAvailability == availability, "Edit availability failed");
        }

        [Test, Order(27)]
        public void AddHoursTest() 
        {
            ProfileExtra profileExtraObj = new ProfileExtra();
            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "ProfileExtra");

            string hours = ExcelUtil.ReadData(2, "Hours");
            profileExtraObj.EditHours(hours);
            
            string addedHours = profileExtraObj.GetHours();          
            Assert.That(addedHours == hours, "Add Hours failed");
        }

        [Test, Order(28)]
        public void EditHoursTest()
        {
            ProfileExtra profileExtraObj = new ProfileExtra();
            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "ProfileExtra");

            string hours = ExcelUtil.ReadData(3, "Hours");
            profileExtraObj.EditHours(hours);

            string editedHours = profileExtraObj.GetHours();
            Assert.That(editedHours == hours, "Edit Hours failed");
        }

        [Test, Order(29)]
        public void AddEarnTargetTest()
        {
            ProfileExtra profileExtraObj = new ProfileExtra();
            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "ProfileExtra");

            string earnTarget = ExcelUtil.ReadData(2, "EarnTarget");
            profileExtraObj.EditEarnTarget(earnTarget);

            string addedEarnTarget = profileExtraObj.GetEarnTarget();
            Assert.That(addedEarnTarget == earnTarget, "Add EarnTarget failed");
        }

        [Test, Order(30)]
        public void EditEarnTargetTest()
        {
            ProfileExtra profileExtraObj = new ProfileExtra();
            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "ProfileExtra");

            string earnTarget = ExcelUtil.ReadData(3, "EarnTarget");
            profileExtraObj.EditEarnTarget(earnTarget);

            string editedEarnTarget = profileExtraObj.GetEarnTarget();
            Assert.That(editedEarnTarget == earnTarget, "Edit EarnTarget failed");
        }

         [Test, Order(31)]
        public void SelectAllNotificationsTest() 
        {
            Notification notificationObj = new Notification();
            bool isSelected = notificationObj.SelectAllNotifications(driver);
            Assert.IsTrue(isSelected);
        }


        [Test, Order(32)]
        public void UnselectNotificationsTest()
        {
            Notification notificationObj = new Notification();
            bool isSelected = notificationObj.UnselectNotifications(driver);
            Assert.IsFalse(isSelected);
        }

        [Test, Order(33)]
        public void SendChatMsgTest()
        {
            Chat chatObj = new Chat();
            string filePath = Environment.CurrentDirectory.ToString() + "\\ExcelData\\TestData.xlsx";
            ExcelUtil.PopulateInCollection(filePath, "Chat");
            string message = ExcelUtil.ReadData(2, "Message");
            chatObj.SendChatMsg(driver, message);

            string latestMsg = chatObj.getChatMsg();
            Assert.That(latestMsg == message, "Meaasge not sent");
        }

    }
}
