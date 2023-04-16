using AdvanceTask_NUnit.Global;
using AdvanceTask_NUnit.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvanceTask_NUnit.Tests
{
    public class Tests:Base
    {
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
        }
    }
}
