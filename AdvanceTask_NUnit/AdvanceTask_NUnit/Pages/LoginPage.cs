using AdvanceTask_NUnit.Global;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_NUnit.Pages
{
    public class LoginPage:Base
    {
        public void SigninActions()
        {
         
            //click on sign in
            IWebElement signIn = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signIn.Click();

           // Wait.TurnOnWait();

            //Populate excel data

            GlobalDefinitions.ExcelUtil.PopulateInCollection(@"C:\Users\solan\Desktop\Group Prject advance task\Task 3\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "SignIn");

            //Enter valid Email Id
            IWebElement emailId = driver.FindElement(By.XPath("//input[@name ='email']"));
            emailId.SendKeys(GlobalDefinitions.ExcelUtil.ReadData(2, "Username"));


            //Enter valid Password
            IWebElement passwordTextBox = driver.FindElement(By.XPath("//input[@name='password']"));
            passwordTextBox.SendKeys(GlobalDefinitions.ExcelUtil.ReadData(2, "Password"));

            //Click on Login
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();


        }

    }
}

