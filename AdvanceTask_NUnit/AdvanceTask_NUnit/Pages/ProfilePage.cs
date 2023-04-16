using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceTask_NUnit.Global;

namespace AdvanceTask_NUnit.Pages
{
    public class ProfilePage:Base
    {
        public void ClickonEducation()
        {

            Wait_Helpers.wait(2000);

            //click on educationtab
            IWebElement educationTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
           // Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 10);
            educationTab.Click();
        }
        public void ManageListings()
        {

            Wait_Helpers.wait(2000);
            //click on ManageListing
            IWebElement managelistingButton = driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));
           // Wait.WaitForElementToBeClickable(driver, "XPath", "//a[@href='/Home/ListingManagement']", 10);
            managelistingButton.Click();
        }

    }
}

