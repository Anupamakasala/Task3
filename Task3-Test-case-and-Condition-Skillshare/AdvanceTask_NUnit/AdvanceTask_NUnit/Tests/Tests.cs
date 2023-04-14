using AdvanceTask_NUnit.Global;
using AdvanceTask_NUnit.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvanceTask_NUnit.Tests
{

    [TestFixture]
    [Parallelizable]
    public class Tests : Base
    {
        SignUp signUpObj;
        LoginPage loginPageObj;
        Notifications notificationsObj;

        public Tests()
        {
            signUpObj = new SignUp();
            loginPageObj = new LoginPage();
            notificationsObj = new Notifications();
        }


        [Test, Order(1), Description("Signup for Portal")]
        public void Register()
        {
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
            try
            {
                test = extentReportObj.CreateTest("Load More notification on the page");
                loginPageObj.LoginSteps();
                notificationsObj.LoadMoreNotification();
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
            try
            {
                test = extentReportObj.CreateTest("Show less notification on the page");
                loginPageObj.LoginSteps();
                notificationsObj.LoadMoreNotification();
                notificationsObj.ShowLessNotification();
                Thread.Sleep(2000);
            
            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }

        }
    }

}

