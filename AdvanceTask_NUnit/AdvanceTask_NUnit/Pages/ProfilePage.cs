using AdvanceTask_NUnit.Global;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_NUnit.Pages
{
    public class ProfilePage : Base
    {
       // public ProfilePage()
        //{
           // PageFactory.InitElements(driver, this);

        //}
        public static IWebElement editDescriptionButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span"));
        public static IWebElement viewDescription => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        public static IWebElement descriptionTextBox => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        public static IWebElement saveButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")); 
        public static IWebElement clickProfileName => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
        public static IWebElement changePassword => driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/span/div/a[2]"));
          //  "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]"));
        public static IWebElement currentPassword => driver.FindElement(By.XPath("//input[@ placeholder='Current Password']"));
            //"/html/body/div[4]/div/div[2]/form/div[1]/input"));
        public static IWebElement newPassword => driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/form/div[2]/input"));
        public static IWebElement confirmPassword => driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/form/div[3]/input"));
        public static IWebElement savePasswordButton => driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/form/div[4]/button"));
        public static IWebElement manageRequests => driver.FindElement(By.XPath("/html/body/div[1]/div/section[1]/div/div[1]"));
     
        public static IWebElement receivedRequests => driver.FindElement(By.XPath("/html/body/div[1]/div/section[1]/div/div[1]/div/a[1]"));
     
        public static IWebElement sentRequests => driver.FindElement(By.XPath("/html/body/div[1]/div/section[1]/div/div[1]/div/a[2]"));
      
        public static IWebElement receivedRequestBody => driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/h2"));
        public static IWebElement SentRequestBody => driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/h2"));

        public void AddDescription(string description)
        {
           

            editDescriptionButton.Click();
            Thread.Sleep(3000);
            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys(description);
            Thread.Sleep(4000);
          //Wait_Helpers.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span", 10);
            saveButton.Click();
            Thread.Sleep(3000);

        }

        public string ViewConfirmation()
        {
            var confirmationMessage = driver.FindElement(By.XPath("/html/body/div[1]/div")).Text; 
            
            return confirmationMessage;
           
        }

        public string ViewDescription()
        {
            var descriptionText = viewDescription.Text;

            return descriptionText;
        }

        public void ChangePassword(string currentProfilePassword, string newProfilePassword)
        {
            clickProfileName.Click();
            Thread.Sleep(4000);
            changePassword.Click();
            currentPassword.SendKeys(currentProfilePassword);
            confirmPassword.SendKeys(newProfilePassword);
            savePasswordButton.Click();

        }

        public string VerifyReceivedRequests()
        {
            manageRequests.Click();
            Thread.Sleep(3000);
            receivedRequests.Click();
            var receivedRequestContent = receivedRequestBody.Text;
            return receivedRequestContent;
        }

        public string VerifySentRequests()
        {
            manageRequests.Click();
            Thread.Sleep(3000);
            sentRequests.Click();
            var sentRequestContent = SentRequestBody.Text;
            return sentRequestContent;
        }

    }
}