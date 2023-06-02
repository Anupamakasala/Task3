using AdvanceTask_NUnit.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;
using static AdvanceTask_NUnit.Global.Wait_Helpers;

namespace AdvanceTask_NUnit.Pages
{
    public class NotificationMoreAndLess : Base
    {
        //Initialize the web elements

        private IWebElement notificationDropdown => driver.FindElement(By.XPath("//i[@class='dropdown icon']"));

        //See all option
        private IWebElement seeAll => driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/span/div/div[2]/div/center/a"));

        //load more to see all notifications
        private IWebElement LoadMore => driver.FindElement(By.XPath("//a[@class='ui button']"));

        //show less to see less notifications
        private IWebElement ShowLess => driver.FindElement(By.XPath("//a[@class='ui button']"));

        // Get the ShowLess Text on Notification Page



        public void LoadMoreNotification()
        {

            //Click on notification drop down
            Wait_Helpers.WaitToBeClickable(driver, "XPath", "//i[@class='dropdown icon']", 10);
            notificationDropdown.Click();

            //Click on see all option
            Wait_Helpers.WaitToBeClickable(driver, "XPath", "/html/body/div[1]/div/div[1]/div[2]/div/div/div/span/div/div[2]/div/center/a", 10);
            seeAll.Click();

            //Click on loadMore option to see all the notifications 
            //wait(2);
            Wait_Helpers.WaitToBeClickable(driver, "XPath", "//a[@class='ui button']", 10);
            LoadMore.Click();
        }


        public string GetShowLessText(IWebDriver driver)
        {
            Wait_Helpers.WaitToExist(driver, "XPath", "/html/body/div[1]/div[2]/div/div/div[3]/div[2]/span/span/div/div[7]/div[1]/center/a", 10);
            IWebElement ShowLessText = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[3]/div[2]/span/span/div/div[7]/div[1]/center/a"));
            return ShowLess.Text;
        }



        public void ShowLessNotification()
        {

            //Click on showless option to see onlylatest notifications
            Thread.Sleep(2000);
            ShowLess.Click();
        }


        public string GetLoadMoreText(IWebDriver driver)
        {
            Wait_Helpers.WaitToExist(driver, "XPath", "/html/body/div[1]/div[2]/div/div/div[3]/div[2]/span/span/div/div[2]/div/center/a", 10);
            IWebElement LoadMoreText = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[3]/div[2]/span/span/div/div[2]/div/center/a"));
            return LoadMoreText.Text;
        }
    }
}
