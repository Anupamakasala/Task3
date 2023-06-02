using OpenQA.Selenium;
using AdvanceTask_NUnit.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;

namespace AdvanceTask_NUnit.Pages
{
    public class SignUp : Base
    {

        //Finding the Join 
        private IWebElement Join => driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/button"));

        //Identify FirstName Textbox
        private IWebElement FirstName => driver.FindElement(By.Name("firstName"));

        //Identify LastName Textbox
        private IWebElement LastName => driver.FindElement(By.Name("lastName"));

        //Identify Email Textbox
        private IWebElement Email => driver.FindElement(By.Name("email"));

        //Identify Password Textbox
        private IWebElement Password => driver.FindElement(By.XPath("//input[@name='password']"));

        //Identify Confirm Password Textbox
        private IWebElement ConfirmPassword => driver.FindElement(By.XPath("//input[@name='confirmPassword']"));

        //Identify Term and Conditions Checkbox
        private IWebElement Checkbox => driver.FindElement(By.XPath("//input[@type='checkbox']"));

        //Identify join button
        private IWebElement JoinBtn => driver.FindElement(By.Id("submit-btn"));


        public void Register()
        {
            //Populate the excel data
            ExcelUtil.PopulateInCollection(Base.excelPath, "Registration");

            //Click on Join button
            Thread.Sleep(3000);
            Join.Click();


            //Enter FirstName
            FirstName.SendKeys(ExcelUtil.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(ExcelUtil.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(ExcelUtil.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(ExcelUtil.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(ExcelUtil.ReadData(2, "ConfirmPassword"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();

        }

        public string GetPopUpMessage(IWebDriver driver)
        {
            IWebElement registrationSuccessfulPopUpMessage = driver.FindElement(By.XPath("/html/body/div[1]/div"));
            return registrationSuccessfulPopUpMessage.Text;

        }

    }
}