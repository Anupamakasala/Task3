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
    public class Login : Base
    {


        private IWebElement SignIn => driver.FindElement(By.XPath("//a[@class='item']"));

        // Finding the Email Field
        private IWebElement Email => driver.FindElement(By.Name("email"));

        //Finding the Password Field
        private IWebElement Password => driver.FindElement(By.Name("password"));

        //Tick the CheckBox Remember me
        private IWebElement Checkbox => driver.FindElement(By.XPath("//input[@name='rememberDetails']"));

        //Finding the Login Button
        private IWebElement LoginBtn => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        //Get the NewName onto Profile
        IWebElement newName => driver.FindElement(By.XPath("//span[@class='item ui dropdown link']"));

        public void LoginSteps()
        {
            //Populate excel data

            ExcelUtil.PopulateInCollection(Base.excelPath, "SignIn");

            //Click on Signin button
            Wait_Helpers.WaitToBeClickable(driver, "XPath", "//a[@class='item']", 10);
            SignIn.Click();

            //Enter email
            Email.SendKeys(ExcelUtil.ReadData(2, "Username"));

            //Enter password
            Password.SendKeys(ExcelUtil.ReadData(2, "Password"));

            //Click the RememberMe Checkbox
            Checkbox.Click();

            //Click Login button
            LoginBtn.Click();
            //wait(2);
        }

        public string GetName(IWebDriver driver)
        {
            Wait_Helpers.WaitToExist(driver, "XPath", "/html/body/div[1]/div/div[1]/div[2]/div/span", 10);
            IWebElement newName = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/span"));
            return newName.Text;
        }


    }

}
