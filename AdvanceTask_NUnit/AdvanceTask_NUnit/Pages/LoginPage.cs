using AdvanceTask_NUnit.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;

namespace AdvanceTask_NUnit.Pages
{
    public class LoginPage : Base
    {


        private IWebElement SignIn => driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));

        // Finding the Email Field
        private IWebElement Email => driver.FindElement(By.Name("email"));

        //Finding the Password Field
        private IWebElement Password => driver.FindElement(By.Name("password"));

        //Finding the Login Button
        private IWebElement LoginBtn => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));


        public void LoginSteps()
        {
            //Populate excel data

            ExcelUtil.PopulateInCollection(Base.excelPath, "LoginPage");

            //Click on Signin button
            Thread.Sleep(3000);
            SignIn.Click();

            //Enter email
            Email.SendKeys(ExcelUtil.ReadData(2, "Username"));

            //Enter password
            Password.SendKeys(ExcelUtil.ReadData(2, "Password"));

            //Click Login button
            LoginBtn.Click();
            //wait(2);

        }

    }
}
