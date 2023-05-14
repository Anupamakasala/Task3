using AdvancedTaskSpecFlow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.Pages
{

    internal class LoginPage : CommonDriver
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

       
        public void LoginSteps(IWebDriver driver)
        {
           
           driver.Manage().Window.Maximize();
           driver.Navigate().GoToUrl("http://localhost:5000/Home");


            //Click on Signin button
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//a[@class='item']", 10);
            SignIn.Click();

            //Enter email
            Email.SendKeys("Taskteam@gmail.com");

            //Enter password
            Password.SendKeys("Shareskill");

            //Click the RememberMe Checkbox
            Checkbox.Click();

            //Click Login button
            LoginBtn.Click();
           
        }

        public string GetName(IWebDriver driver)
        {
            WaitHelpers.WaitToExist(driver,"XPath","/html/body/div[1]/div/div[1]/div[2]/div/span",10);
            IWebElement newName = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/span"));
            return newName.Text;
        }
    }
}


    

       

