using AdvanceTask_NUnit.Global;
using OpenQA.Selenium.Support.UI;
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
        public Login()
        {
           ExcelUtil.PopulateInCollection(excelPath, "SignIn");
        }
        IWebElement SignInButton => driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
        IWebElement UserNameTextbox => driver.FindElement(By.Name("email"));
        IWebElement PasswordTextbox => driver.FindElement(By.XPath("//input[@type='password']"));
        IWebElement Checkbox => driver.FindElement(By.XPath("//input[@name='rememberDetails']"));
        IWebElement LoginButton => driver.FindElement(By.XPath("//button[@class='fluid ui teal button'][text()='Login']"));
        IWebElement newName => driver.FindElement(By.XPath("//span[@class='item ui dropdown link']"));

        public void LoginSteps()
        {
            //Populate  the excel data
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            ExcelUtil.PopulateInCollection(Base.excelPath, "SignIn");

            //Login
            Thread.Sleep(3000);
            SignInButton.Click();

            //For Username
            UserNameTextbox.SendKeys(ExcelUtil.ReadData(2, "Username"));

            //For Password
            PasswordTextbox.SendKeys(ExcelUtil.ReadData(2, "Password"));

            //To click on the checkbox
            Checkbox.Click();

            //Click on the Login Button
            LoginButton.Click();
            

        }

        public string GetName(IWebDriver driver)
        {
            return newName.Text;
        }
    }
}