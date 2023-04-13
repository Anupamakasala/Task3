using AdvanceTask_NUnit.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_NUnit.Pages
{
    public class LoginPage : Base
    {
        public static IWebElement signInButton => driver.FindElement(By.XPath("//a[@class='item']"));
        public static IWebElement emailAddressTextbox => driver.FindElement(By.XPath("//input[@name='email']"));
        public static IWebElement passwordTextBox => driver.FindElement(By.XPath("//input[@name='password']"));
        public static IWebElement loginButton => driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));


        public LoginPage(string username, string password)
        {
            Wait_Helpers.WaitToBeClickable(driver, "XPath", "//a[@class='item']", 10);

            signInButton.Click();
            emailAddressTextbox.SendKeys(username);
            passwordTextBox.SendKeys(password);
            loginButton.Click();


        }

    }
}
