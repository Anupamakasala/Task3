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


        public void LoadMoreNotification()
        {

            //Click on notification drop down
            Thread.Sleep(2000);
            notificationDropdown.Click();

            //Click on see all option
            Thread.Sleep(2000);
            seeAll.Click();

            //Click on loadMore option to see all the notifications 
            wait(2);
            LoadMore.Click();


        }

        public void ShowLessNotification()
        {

            //Click on showless option to see onlylatest notifications
            Thread.Sleep(2000);
            ShowLess.Click();
        }
    }
}