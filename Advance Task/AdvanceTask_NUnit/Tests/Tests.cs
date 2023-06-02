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
